using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace JowharProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager ctm = new ContactManager(new EfContactDal());
        // GET: Contact
        public ActionResult Index(int page = 1)
        {
            var contactvalue = ctm.GetList().ToPagedList(page, 3);
            return View(contactvalue);
        }
        /*----------------------------------ADD-------------------------------------*/
        [HttpGet]
        public ActionResult ContactSend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactSend(Contact p)
        {
            ContactValidator contactValidator = new ContactValidator();
            ValidationResult results = contactValidator.Validate(p);
            if (results.IsValid)
            {
                p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                ctm.ContactAdd(p);
                return RedirectToAction("Home","Index");
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
        /*----------------------------------Delete-------------------------------------*/
        public ActionResult ContactDelete(int id)
        {
            var ContactValue = ctm.GetByID(id);
            ContactValue.UserStatus = false;
            ctm.ContactDelete(ContactValue);
            return RedirectToAction("Index");
        }
    }
}