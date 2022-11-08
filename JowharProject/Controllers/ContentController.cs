using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace JowharProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager ctm = new ContentManager(new EfContentDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: Content
        public ActionResult ContentIndex(int page = 1)
        {
            var contentvalue = ctm.GetList().ToPagedList(page, 3);
            return View(contentvalue);
        }
        //public ActionResult ContentByHeading(int id)
        //{
        //    var contentvalues = cm.GetListByHeadingID(id);
        //    return View(contentvalues);
        //}
        //-----------------------------Add----------------------
        [HttpGet]
        public ActionResult Add()
        {
            //Dropdown'dan veri çekme işlemi
            List<SelectListItem> valueheading = (from x in hm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.HeadingName,
                                                     Value = x.HeadingID.ToString()
                                                 }).ToList();
            ViewBag.vlh = valueheading;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ctm.ContentAdd(p);
            return RedirectToAction("ContentIndex");
        }
        //public PartialViewResult AddContent()
        //{
        //    return PartialView();
        //}

        /*----------------------------------Delete-------------------------------------*/
        public ActionResult ContentDelete(int id)
        {
            var contentValue = ctm.GetByID(id);
            contentValue.ContentStatus = false;
            ctm.ContentDelete(contentValue);
            return RedirectToAction("ContentIndex");
        }
    }
}