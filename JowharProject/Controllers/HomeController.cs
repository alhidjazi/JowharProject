using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace JowharProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager ctm = new ContentManager(new EfContentDal());
        // GET: Home
        public ActionResult Index(int page = 1)
        {
            var categoryvalue = cm.GetList().ToPagedList(page, 1);
            return View(categoryvalue);
        }
        //---------------------------------------------------------------------------
        public ActionResult JowharAcademy()
        {
            var categoryvalue = cm.GetList();
            return View(categoryvalue);
        }
        public ActionResult JowharPeaceJustice()
        {
            var categoryvalue = cm.GetList();
            return View(categoryvalue);
        }
        public ActionResult JowharEconomicSocial()
        {
            var categoryvalue = cm.GetList();
            return View(categoryvalue);
        }
        public ActionResult JowharAcademyPolicy()
        {
            var headingvalue = hm.GetList();
            return View(headingvalue);
        }


        //---------------------------------------------------------------------------
        public ActionResult Heading(int page = 1)
        {
            var headingvalue = hm.GetList().ToPagedList(page, 1);
            return View(headingvalue);
        }

        public PartialViewResult partner()
        {
            return PartialView();
        }
    }
}