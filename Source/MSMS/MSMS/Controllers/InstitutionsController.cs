using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSMS.Models;
using MSMS.Repository;
using System.IO;
using System.Web.Helpers;

namespace MSMS.Controllers
{
    public class InstitutionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Institutions
        public ActionResult Index()
        {
            return View(db.Institutions.ToList());
        }

        // GET: Institutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institution institution = db.Institutions.Find(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        // GET: Institutions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Institutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Slogan,Address,InstitutionCode,LogoURL,EstDate")] Institution institution, HttpPostedFileBase fileLogo)
        public ActionResult Create(Institution institution, HttpPostedFileBase fileLogo)
        {

            if (ModelState.IsValid)
            {
                //Save image to a folder
                string pic = System.IO.Path.GetFileName(fileLogo.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images/Logo"), pic);
                //fileLogo.SaveAs(path);

                WebImage img = new WebImage(fileLogo.InputStream);
                if (img.Width > 50)
                    img.Resize(50, 50);
                img.Save(path, null, false);
                //img.Save("Images/path");

                //logo dirctory
                institution.LogoURL = "~/Images/Logo/" + pic;

                db.Institutions.Add(institution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(institution);
        }

        // GET: Institutions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institution institution = db.Institutions.Find(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        // POST: Institutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Institution institution, HttpPostedFileBase fileLogo)
        {
            if (ModelState.IsValid)
            {
                // Save image to a folder
                string pic = System.IO.Path.GetFileName(fileLogo.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images/Logo"), pic);
                //fileLogo.SaveAs(path);

                WebImage img = new WebImage(fileLogo.InputStream);
                if (img.Width > 50)
                    img.Resize(50, 50);
                img.Save(path, null, false);
                //img.Save("Images/path");

                //logo dirctory
                institution.LogoURL = "~/Images/Logo/" + pic;

                db.Entry(institution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(institution);
        }

        // GET: Institutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institution institution = db.Institutions.Find(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        // POST: Institutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Institution institution = db.Institutions.Find(id);
            db.Institutions.Remove(institution);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private string ProcessImage(string croppedImage)
        {
            string filePath = String.Empty;
            try
            {
                string base64 = croppedImage;
                byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
                filePath = "/Images/Photo/Emp-" + Guid.NewGuid() + ".png";
                using (FileStream stream = new FileStream(Server.MapPath(filePath), FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                string st = ex.Message;
            }

            return filePath;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
