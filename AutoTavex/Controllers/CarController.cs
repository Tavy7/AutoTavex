using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoTavex.Models;

namespace AutoTavex.Controllers
{
    
    public class CarController : Controller
    {
        DatabaseContext _context;

        public CarController()
        {
            _context = new DatabaseContext;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Car
        public ActionResult Index()
        {
            var cars = _context.Cars;
            return View(cars);
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}