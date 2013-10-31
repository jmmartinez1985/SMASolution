using SMAWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Script.Serialization;
using System.Web.WebPages.Html;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Transactions;
using SMAWeb.Extensions;

namespace SMAWeb.HttpHandler
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler, IRequiresSessionState
    {

        private readonly JavaScriptSerializer js;

        string _StorageRoot, _ExtraRoot;


        private string StorageRoot
        {
            get { return Path.Combine(System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FilesUploaded"].ToString())); } //Path should! always end with '/'
            set { _StorageRoot = value; }
        }
        private string ExtraRoot
        {
            get { return Path.Combine(System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ContenidoMultimedia"].ToString())); } //Path should! always end with '/'
            set { _ExtraRoot = value; }
        }

        public UploadHandler()
        {
            js = new JavaScriptSerializer();
            js.MaxJsonLength = 41943040;
        }

        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Pragma", "no-cache");
            context.Response.AddHeader("Cache-Control", "private, no-cache");

            HandleMethod(context);
        }

        // Handle request based on method
        private void HandleMethod(HttpContext context)
        {

            switch (context.Request.HttpMethod)
            {
                case "HEAD":
                case "GET":
                    if (GivenFilename(context)) DeliverFile(context);
                    else ListCurrentFiles(context);
                    break;

                case "POST":
                case "PUT":
                    if (context.Request["id"] != null | context.Request["f"] != null)
                    {
                        DeleteFile(context);
                    }
                    else
                        UploadFile(context);
                    break;

                case "DELETE":
                    DeleteFile(context);
                    break;

                case "OPTIONS":
                    ReturnOptions(context);
                    break;

                default:
                    context.Response.ClearHeaders();
                    context.Response.StatusCode = 405;
                    break;
            }
        }

        private static void ReturnOptions(HttpContext context)
        {
            context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
            context.Response.StatusCode = 200;
        }

        // Delete file from the server
        private void DeleteFile(HttpContext context)
        {

            if (context.Request["id"] != null)
            {
                using (var db = new Entities())
                {
                    var extra = db.AE_AnunciosExtras.Find(int.Parse(context.Request["id"].ToString()));
                    var currentPath = ExtraRoot + extra.AN_Id + @"\" + extra.AN_Nombre;
                    if (File.Exists(currentPath))
                    {
                        File.Delete(currentPath);
                    }
                    db.AE_AnunciosExtras.Remove(extra);
                    db.SaveChanges();

                }
            }
            else
            {
                var filePath = System.Web.HttpContext.Current.Server.MapPath(context.Request["f"]);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        // Upload file to the server
        private void UploadFile(HttpContext context)
        {
            var statuses = new List<FilesStatus>();
            var headers = context.Request.Headers;

            if (string.IsNullOrEmpty(headers["X-File-Name"]))
            {
                UploadWholeFile(context, statuses);
            }
            else
            {
                UploadPartialFile(headers["X-File-Name"], context, statuses);
            }

            WriteJsonIframeSafe(context, statuses);
        }

        // Upload partial file
        private void UploadPartialFile(string fileName, HttpContext context, List<FilesStatus> statuses)
        {
            if (context.Request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var inputStream = context.Request.Files[0].InputStream;
            var fullName = StorageRoot + Path.GetFileName(fileName);

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new FilesStatus(new FileInfo(fullName)));
        }

        // Upload entire file
        private void UploadWholeFile(HttpContext context, List<FilesStatus> statuses)
        {
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                var file = context.Request.Files[i];
                var path = string.Empty;

                var currentPath = string.Empty;

                if (HttpContext.Current.Session["Anuncio"] != null)
                {
                    currentPath = ExtraRoot + HttpContext.Current.Session["Anuncio"] + "/";
                    path = System.Configuration.ConfigurationManager.AppSettings["ContenidoMultimedia"].ToString() + HttpContext.Current.Session["Anuncio"] + @"/" + Path.GetFileName(file.FileName);

                }
                else if (HttpContext.Current.Session["AdminResource"] != null)
                {
                    currentPath = string.Format(ExtraRoot + "Admin/");
                    path = System.Configuration.ConfigurationManager.AppSettings["FilesUploaded"].ToString() + "Admin/" + Path.GetFileName(file.FileName);
                }

                else if(HttpContext.Current.Session["Anuncio"] == null | HttpContext.Current.Session["AdminResource"] == null)
                {
                    currentPath = StorageRoot;
                    path = System.Configuration.ConfigurationManager.AppSettings["FilesUploaded"].ToString() + Path.GetFileName(file.FileName);
                }


                var fullPath = currentPath + Path.GetFileName(file.FileName);

                file.SaveAs(fullPath);

                string fullName = Path.GetFileName(file.FileName);

                statuses.Add(new FilesStatus(fullName, file.ContentLength, fullPath, path));

               
            }

            if (HttpContext.Current.Session["Anuncio"] != null)
                SaveContent(statuses);
        }

        private void SaveContent(List<FilesStatus> files)
        {
            using (var tran = new TransactionScope())
            {
                using (var db = new Entities())
                {
                    files.ForEach(c =>
                    {
                        db.AE_AnunciosExtras.Add(new AE_AnunciosExtras
                        {
                            AN_Id = int.Parse(HttpContext.Current.Session["Anuncio"].ToString()),
                            AN_ImagenUrl = c.UrlPath,
                            AN_Nombre = Path.GetFileName(c.UrlPath)
                        });

                    });
                    db.SaveChanges();
                }
                tran.Complete();
            }

        }

        private void WriteJsonIframeSafe(HttpContext context, List<FilesStatus> statuses)
        {
            context.Response.AddHeader("Vary", "Accept");
            try
            {
                if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    context.Response.ContentType = "application/json";
                else
                    context.Response.ContentType = "text/plain";
            }
            catch
            {
                context.Response.ContentType = "text/plain";
            }

            var jsonObj = statuses.SerializeToJson();
            context.Response.Write(jsonObj);
        }


        private static bool GivenFilename(HttpContext context)
        {
            return !string.IsNullOrEmpty(context.Request["f"]);
        }

        private void DeliverFile(HttpContext context)
        {
            var filename = context.Request["f"];
            var filePath = StorageRoot + filename;

            if (File.Exists(filePath))
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(filePath);
            }
            else
                context.Response.StatusCode = 404;
        }

        private void ListCurrentFiles(HttpContext context)
        {
            var files =
                new DirectoryInfo(StorageRoot)
                    .GetFiles("*", SearchOption.TopDirectoryOnly)
                    .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                    .Select(f => new FilesStatus(f))
                    .ToArray();

            string jsonObj = js.Serialize(files);
            context.Response.AddHeader("Content-Disposition", "inline; filename=\"files.json\"");
            context.Response.Write(jsonObj);
            context.Response.ContentType = "application/json";
        }

    }
}