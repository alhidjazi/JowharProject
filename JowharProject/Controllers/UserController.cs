using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JowharProject.Controllers
{
    public class UserController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult MyContent(string p)
        //{
        //    p = (string)Session["UserMail"];
        //    var userifo = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
        //    var contentvalues = cm.GetListByUser(userifo);
        //    return View(contentvalues);
        //}
        //[HttpGet]
        //public ActionResult AddContent(int id)
        //{
        //    ViewBag.d = id;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddContent(Content p)
        //{
        //    string mail = (string)Session["UserMail"];
        //    var userifo = c.Users.Where(x => x.UserMail == mail).Select(y => y.UserID).FirstOrDefault();

        //    p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    p.UserID = userifo;
        //    p.ContentStatus = true;
        //    cm.ContentAdd(p);
        //    return RedirectToAction("MyContent");
        //}
    }
}