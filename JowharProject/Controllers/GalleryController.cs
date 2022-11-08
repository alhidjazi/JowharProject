using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace JowharProject.Controllers
{
    public class GalleryController : Controller
    {
        GalleryManager gm = new GalleryManager(new EfGalleryDal());
        
        // GET: Gallery
        public ActionResult Index(int page = 1)
        {
            var file = gm.GetList().ToPagedList(page, 6);
            return View(file);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Gallery p)
        {
            GalleryValidator galleryValidator = new GalleryValidator();
            ValidationResult results = galleryValidator.Validate(p);

            if (results.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                        string uzanti = Path.GetExtension(Request.Files[0].FileName);
                        string yol = "~/images/" + dosyaadi + uzanti;
                        Request.Files[0].SaveAs(Server.MapPath(yol));
                        p.ImagePath = "/images/" + dosyaadi + uzanti; 
                    }
                    gm.GalleryAdd(p);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        //------------------------------------Delete-------------------------------------------
        public ActionResult Delete(int id)
        {
            var galleryvalue = gm.GetByID(id);
            gm.GalleryDelete(galleryvalue);
            return RedirectToAction("Index");
        }
        //------------------------------------Update-------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var galleryvalue = gm.GetByID(id);
            return View(galleryvalue);
        }
        [HttpPost]
        public ActionResult Edit(Gallery p)
        {
            gm.GalleryUpdate(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult Gall()
        {
            return PartialView();
        }
        public PartialViewResult EditGallery()
        {
            return PartialView();
        }
    }
}