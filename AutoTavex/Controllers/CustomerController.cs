using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoTavex.Models;

namespace AutoTavex.Controllers
{
    public class CustomerController : Controller
    {
        DatabaseContext _context;
        public CustomerController()
        {
            _context = new DatabaseContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Edit()
        {
            string email = "";
            if (User.Identity.IsAuthenticated)
                email = User.Identity.Name;

            var customer = _context.Customers.SingleOrDefault(c => c.Email == email);

            if (customer is null)
            {
                var newCustomer = new Customer
                {
                    Email = email
                };
                
                return View("Form", newCustomer);
            }

            return View("Form", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Email == customer.Email);

                if (customerInDb == null)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    customerInDb.Name = customer.Name;
                    customerInDb.CNP = customer.CNP;
                    customerInDb.IsOver18 = customer.IsOver18;
                }
                _context.SaveChanges();
            }

            return View("Form", customer);
        }
    }
}