using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccessLayer.Concrete;
using Context = DataAccessLayer.Concrete.Context;

namespace JowharProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        //GET: Login
        UserLoginManager um = new UserLoginManager(new EfUserDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {

            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                //işlemler
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User p)
        {
            var userinfo = um.GetUser(p.UserMail, p.UserPassword);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.UserMail, false);
                Session["UserMail"] = userinfo.UserMail;
                //işlemler
                return RedirectToAction("Index", "Heading");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}