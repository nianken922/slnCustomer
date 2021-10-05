using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCustomer.Models;
using PagedList;

namespace prjCustomer.Controllers
{
    public class HomeController : Controller
    {
        dbCustomerEntities db = new dbCustomerEntities();
        int pagesize = 5;
        // GET: Home
        public ActionResult Index(int page=1)
        {
            int currentPage = page < 1 ? 1 : page;
            var customers = db.tCustomer.OrderBy(m => m.fId).ToList();
            var result = customers.ToPagedList(currentPage, pagesize);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(tCustomer vCustomer)
        {
            db.tCustomer.Add(vCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int fId)
        {
            var customers = db.tCustomer.Where(m => m.fId==fId).FirstOrDefault();
            db.tCustomer.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int fId)
        {
            var customers = db.tCustomer.Where(m => m.fId==fId).FirstOrDefault();
            return View(customers);
        }
        [HttpPost]

        public ActionResult Edit(tCustomer vCustomer)
        {
            int fId = vCustomer.fId;
            var customers = db.tCustomer.Where(m => m.fId == fId).FirstOrDefault();
            customers.fName = vCustomer.fName;
            customers.fPhone = vCustomer.fPhone;
            customers.fAddress = vCustomer.fAddress;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int fId)
        {
            var customers = db.tCustomer.Where(m => m.fId == fId).FirstOrDefault();
            return View(customers);
        }
        

        
    }
}