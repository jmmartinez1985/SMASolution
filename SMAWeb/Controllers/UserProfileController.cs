using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMAWeb.Models;
using SMAWeb.Extensions;
using System.IO;
using WebMatrix.WebData;

using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Drawing;

namespace SMAWeb.Controllers
{
    public class UserProfileController : BaseController
    {
        private Entities db = new Entities();

        //
        // GET: /UserProfile/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var userprofile = db.UserProfile.Include(u => u.MB_Membresia).Include(u => u.PA_Paises).Include(u => u.ST_Estatus);
            return View(userprofile.ToList());
        }

        //
        // GET: /UserProfile/Details/5
        [Authorize(Roles = "Users, Admin")]
        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Create

        public ActionResult Create()
        {
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion");
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion");
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion");
            return View();
        }

        //
        // POST: /UserProfile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                if (userprofile.Image.ToString() == string.Empty)
                {
                    userprofile.Image = "~/Images/No_Profile.jpg";
                }

                db.UserProfile.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Edit/5
        [Authorize(Roles = "Users, Admin")]
        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Edit/5
        [Authorize(Roles = "Users, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Delete/5
        [Authorize(Roles = "Users, Admin")]
        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /UserProfile/Delete/5
        [Authorize(Roles = "Users, Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfile.Find(id);
            db.UserProfile.Remove(userprofile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /UserProfile/EditUser/5
        [Authorize(Roles = "Users, Admin")]
        public ActionResult EditUser()
        {
            int id = WebSecurity.CurrentUserId;
            UserProfile userprofile = db.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            ViewBag.userpic = userprofile.Image;
            return View(userprofile);
        }

        //
        // POST: /UserProfile/EditUser/5
        [Authorize(Roles = "Users, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                if (TempData["UserImage"] != null)
                {
                    userprofile.Image = TempData["UserImage"].ToString();
                }
                else
                {
                    userprofile.Image = "~/Images/No_Profile.jpg";
                }
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditUser", "UserProfile", new { id = WebSecurity.CurrentUserId });
            }
            ViewBag.MP_MemberShipId = new SelectList(db.MB_Membresia, "MP_MemberShipId", "MP_Descripcion", userprofile.MP_MemberShipId);
            ViewBag.PA_Id = new SelectList(db.PA_Paises, "PA_Id", "PA_Descripcion", userprofile.PA_Id);
            ViewBag.ST_Id = new SelectList(db.ST_Estatus, "ST_Id", "ST_Descripcion", userprofile.ST_Id);
            return View(userprofile);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public FileContentResult GetUserImage(int id)
        {
            var image = db.UserProfile.Find(id).Image;
            var bytes = new byte[1024];
            if (image != null)
            {
                using (FileStream fs = new FileStream(Server.MapPath(image), FileMode.Open))
                {
                    bytes = ReadFully(fs);
                }
            }
            return bytes != null ? new FileContentResult(bytes, "image/jpg") : null;

        }

        public ActionResult UploadFiles()
        {
            var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                var findUser = db.UserProfile.FirstOrDefault(c => c.UserId == WebSecurity.CurrentUserId);
                if (findUser != null)
                {
                    //string savedFileName = Path.Combine(
                    //   AppDomain.CurrentDomain.BaseDirectory, "FilesUploaded", "Profiles",
                    //   Path.GetFileName(hpf.FileName));

                    string savedFileName = System.Web.HttpContext.Current.Server.MapPath(string.Format("~/FilesUploaded/Profiles/{0}", Path.GetFileName(hpf.FileName)));

                    hpf.SaveAs(savedFileName);
                    findUser.Image = "~/FilesUploaded/Profiles/" + Path.GetFileName(hpf.FileName);
                    if (TempData.ContainsKey("UserImage"))
                        TempData.Remove("UserImage");
                    TempData.Add("UserImage", findUser.Image);
                    db.Entry(findUser).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("EditUser", "UserProfile", new { id = WebSecurity.CurrentUserId });
                }
            }
            return null;
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }


        [HttpPost]
        public string UploadOriginalImage(HttpPostedFileBase img)
        {
            string folder = Server.MapPath("~/Temp");
            string extension = Path.GetExtension(img.FileName);
            string pic = System.IO.Path.GetFileName(Guid.NewGuid().ToString());
            var tempPath = Path.ChangeExtension(pic, extension);
            string tempFilePath = System.IO.Path.Combine(folder, tempPath);

            bool exists = System.IO.Directory.Exists(folder);
            if (!exists)
                System.IO.Directory.CreateDirectory(folder);

            img.SaveAs(tempFilePath);
            var image = System.Drawing.Image.FromFile(tempFilePath);
            var result = new
            {
                status = "success",
                width = image.Width,
                height = image.Height,
                url = Url.Action(tempPath, "Temp")
            };
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string CroppedImage(string imgUrl, int imgInitW, int imgInitH, double imgW, double imgH, int imgY1, int imgX1, int cropH, int cropW)
        {
            var originalFilePath = Server.MapPath(imgUrl);
            var fileName = CropImage(originalFilePath, imgInitW, imgInitH, (int)imgW, (int)imgH, imgY1, imgX1, cropH, cropW);
            var result = new
            {
                status = "success",
                url = "/FilesUploaded/Profiles/" + fileName
            };

            var findUser = db.UserProfile.FirstOrDefault(c => c.UserId == WebSecurity.CurrentUserId);
            if (findUser != null)
            {
                findUser.Image = "~/FilesUploaded/Profiles/" + Path.GetFileName(fileName);
                db.Entry(findUser).State = EntityState.Modified;
                db.SaveChanges();
            }
            return JsonConvert.SerializeObject(result);
        }

        private string CropImage(string originalFilePath, int origW, int origH, int targetW, int targetH, int cropStartY, int cropStartX, int cropW, int cropH)
        {
            var originalImage = System.Drawing.Image.FromFile(originalFilePath);


            var resizedOriginalImage = new Bitmap(originalImage, targetW, targetH);
            //var resizedOriginalImage = new Bitmap(originalImage, targetH, targetW);

            //var targetImage = new Bitmap(cropW, cropH);
            var targetImage = new Bitmap(cropH, cropW);

            using (var g = Graphics.FromImage(targetImage))
            {
                //g.DrawImage(resizedOriginalImage, new Rectangle(0, 0, cropW, cropH), new Rectangle(cropStartX, cropStartY, cropW, cropH), GraphicsUnit.Pixel);
                g.DrawImage(resizedOriginalImage, new Rectangle(0, 0, cropH, cropW), new Rectangle(cropStartX, cropStartY, cropH, cropW), GraphicsUnit.Pixel);
            }
            string fileName = Path.GetFileName(originalFilePath);
            var folder = Server.MapPath("~/FilesUploaded/Profiles/");
            string croppedPath = Path.Combine(folder, fileName);
            bool exists = System.IO.Directory.Exists(folder);
            if (!exists)
                System.IO.Directory.CreateDirectory(folder);

            targetImage.Save(croppedPath);

            return fileName;

        }

    }
    public class ViewDataUploadFilesResult
    {
        public string Name { get; set; }
        public int Length { get; set; }
    }

}