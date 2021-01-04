using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoTavex.Models;
using AutoTavex.ViewModels;

namespace AutoTavex.Controllers
{
    
    public class CarController : Controller
    {
        DatabaseContext _context;
        public CarController()
        {
            _context = new DatabaseContext();
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

        // Get: Add
        public ActionResult Add()
        {
            var viewModel = new CarFormViewmodel
            {
                Title = "Add"
            };

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car)
        {
            // MEREU E INVALID DESI DATELE SUNT OKK
            if (!ModelState.IsValid)
            {
                // Daca modelul nu e valid ne intoarcem pe pagina
                var viewModel = new CarFormViewmodel
                {
                    Title = CarFormViewmodel.Add,
                    Car = car
                };

                return View("Form", viewModel);
            }

            if (car.Id == 0)
            {
                // Daca masina este nou adaugata o introducem in Db
                _context.Cars.Add(car);
            }
            else
            {
                // Daca masina este editata o updatam in Db
                var carInDb = _context.Cars.Single(c => c.Id == car.Id);
                carInDb.Id = car.Id;
                carInDb.Manufacturer = car.Manufacturer;
                carInDb.Series = car.Series;
                carInDb.Vin = car.Vin;
                carInDb.CylindricalCapacity = car.CylindricalCapacity;
                carInDb.HorsePower = car.HorsePower;
                carInDb.YearManufactured = car.YearManufactured;
                carInDb.HasThermalEngine = car.HasThermalEngine;
                carInDb.IsHybrid = car.IsHybrid;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Doar pt admin
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            
            if (car == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CarFormViewmodel
            {
                Title = CarFormViewmodel.Edit,
                Car = car
            };

            return View("Form", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            _context.Cars.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // De facut functie pentru details
    }
}