using System;
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

        [Route("Car/Add/")]
        public ActionResult Add()
        {
            var viewModel = new CarFormViewmodel(0);

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car, HttpPostedFileBase image)
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

                if (car.Id > 0)
                {
                    viewModel.Title = CarFormViewmodel.Edit;
                }

                return View("Form", viewModel);
            }

            if (image != null)
            {
                image.SaveAs(HttpContext.Server.MapPath("~\\Content\\Images\\" + image.FileName));
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
                carInDb.Image = "~\\Content\\Images\\" + car.Image;
                carInDb.ExtraDetails = car.ExtraDetails;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Doar pt admin
        [Route("Car/Edit/{id}")]
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

        [Route("Car/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            _context.Cars.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Route("Car/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            

            return View(car);
        }
    }
}