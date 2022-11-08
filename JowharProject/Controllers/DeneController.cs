using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JowharProject.Controllers
{
    [AllowAnonymous]
    public class DeneController : Controller
    {
        // GET: Dene
        GalleryManager gm = new GalleryManager(new EfGalleryDal());
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dene/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dene/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dene/Create
        [HttpPost]
        public ActionResult Create(Gallery p, HttpPostedFileBase imagefil)
        {
            try
            {
                // TODO: Add insert logic here
                if (imagefil!=null)
                {
                    var image = Path.GetFileName(imagefil.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), image);
                    imagefil.SaveAs(path);
                    p.ImagePath = "/images/.jpg" + image;

                    gm.GalleryAdd(p);
                    
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            catch
            {
                return View();
            }
        }

        // GET: Dene/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dene/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dene/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dene/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
