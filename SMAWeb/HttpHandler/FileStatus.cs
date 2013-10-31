using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SMAWeb.HttpHandler
{

    public class FilesStatus
    {
        public const string HandlerPath = "/HttpHandler/";

        public string group { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string progress { get; set; }
        public string url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_url { get; set; }
        public string delete_type { get; set; }
        public string error { get; set; }
        public string UrlPath { get; set; }
        public int IdResource { get; set; }

        public FilesStatus() { }

        public FilesStatus(FileInfo fileInfo) { SetValues(fileInfo.Name, (int)fileInfo.Length, fileInfo.FullName, null); }

        public FilesStatus(string fileName, int fileLength, string fullPath, string NewPath)
        {
            SetValues(fileName, fileLength, fullPath, NewPath);
        }

        private void SetValues(string fileName, int fileLength, string fullPath, string NewPath)
        {
            name = fileName;
            type = System.Web.MimeMapping.GetMimeMapping(fileName);
            size = fileLength;
            progress = "1.0";
            url = "?f=" + NewPath.Replace(" ", "_");
            delete_url = HandlerPath + "UploadHandler.ashx?f=" + NewPath.Replace(" ", "_");
            delete_type = "DELETE";
            UrlPath = NewPath.Replace(" ", "_");

            var ext = Path.GetExtension(fullPath);

            var fileSize = ConvertBytesToMegabytes(new FileInfo(fullPath).Length);
            if (fileSize > 3 || !IsImage(ext)) thumbnail_url = "/Content/img/generalFile.png";
            else thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath);
        }

        private bool IsImage(string ext)
        {
            return ext == ".gif" || ext == ".jpg" || ext == ".png";
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
