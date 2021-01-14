using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoTavex.Models;

namespace AutoTavex.Controllers
{
    public class VehicleEventController : Controller
    {
        DatabaseContext _context;
        public VehicleEventController()
        {
            _context = new DatabaseContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: VehicleEvent
        public ActionResult Index()
        {
            //var vehicleEvents = _context.Events;

            var vehicleEvents = new VehicleEvent
            {
                EventCars = _context.Cars,
                EventMoto = _context.Moto,
                CustomerVehicles = _context.Customers

            };

            return View(vehicleEvents);
        }
    }
}