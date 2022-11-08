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
    public class PartnerController : Controller
    {
        PartnerManager pm = new PartnerManager(new EfPartnerDal());
        // GET: Partner
        public ActionResult Index(int page = 1)
        {
            var partnervalue = pm.GetList().ToPagedList(page, 3);
            return View(partnervalue);
        }
        [HttpGet]
        public ActionResult AddPartner()
        {
            List<SelectListItem> valuepartner = (from x in pm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Selected = x.PartnerStatus,
                                                     Value = x.PartnerID.ToString()
                                                 }).ToList();
            ViewBag.vlp = valuepartner;
            return View();
        }
        [HttpPost]
        public ActionResult AddPartner(Partner p)
        {
            PartnerValidator partnerValidator = new PartnerValidator();
            ValidationResult results = partnerValidator.Validate(p);
            if (results.IsValid)
            {
                pm.PartnerAdd(p);
                return RedirectToAction("Index");
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
        //------------------------------------Update-------------------------------------------
        [HttpGet]
        public ActionResult EditPartner(int id)
        {
            List<SelectListItem> valuepartner = (from x in pm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.PartnerName,
                                                      Value = x.PartnerID.ToString()
                                                  }).ToList();
            ViewBag.vlp = valuepartner;

            var partnervalue = pm.GetByID(id);
            return View(partnervalue);
        }
        [HttpPost]
        public ActionResult EditPartner(Partner p)
        {
            pm.PartnerUpdate(p);
            return RedirectToAction("Index");
        }
        //------------------------------------DELETE-------------------------------------------

        public ActionResult Delete(int id)
        {
            var PartnerValue = pm.GetByID(id);
            PartnerValue.PartnerStatus = false;
            pm.PartnerDelete(PartnerValue);
            return RedirectToAction("Index");
        }
    }
}