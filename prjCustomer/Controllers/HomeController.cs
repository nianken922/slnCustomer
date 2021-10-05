using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCustomer.Models;

namespace prjCustomer.Controllers
{
    public class HomeController : Controller
    {
        dbCustomerEntities db = new dbCustomerEntities();
        // GET: Home
        public ActionResult Index()
        {
            var customers = db.tCustomer.OrderBy(m => m.fId).ToList();
            return View(customers);
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