using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
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
            if (User.IsInRole(RoleName.CanManageVehicles))
            {
                return View("List", cars);
            }

            return View("ReadOnlyList", cars);
        }

        [Route("Car/Add/")]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Add()
        {
            var viewModel = new CarFormViewmodel(0);

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car, HttpPostedFileBase image)
        {
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
                string imagePath = "~\\Content\\Images\\" + image.FileName;
                image.SaveAs(HttpContext.Server.MapPath(imagePath));
                car.Image = imagePath;
            }

            if (car.Image != null && car.Image[0] != '~')
            {
                string path = "~\\Content\\Images\\" + car.Image.ToString();
                car.Image = path;
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
                carInDb.Image = car.Image;
                carInDb.ExtraDetails = car.ExtraDetails;
                carInDb.Price = car.Price;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Doar pt admin
        [Route("Car/Edit/{id}")]
        [Authorize(Roles = RoleName.CanManageVehicles)]
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
        [Authorize(Roles = RoleName.CanManageVehicles)]
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
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            

            return View(car);
        }

        public ActionResult Buy(int id)
        {
            string email = User.Identity.Name;
            Customer customer = _context.Customers.Single(c => c.Email == email);
            Car car = _context.Cars.Single(c => c.Id == id);

            Insurance insurance = new Insurance
            {
                CustomerName = customer.Name,
                CustomerCNP = customer.CNP,
                CarName = car.Manufacturer + " " + car.Series,
                CarVIN = car.Vin,
                CarId = car.Id,
                ContractValue = 5 * car.Price / 100
            };

            return View("Buy", insurance);
        }
        public ActionResult CarSold(Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Buy//" + insurance.CarId.ToString());
            }

            // Daca modelul e valid adaugam asigurarea in baza de date
            _context.Insurances.Add(insurance);
            // Modificam pretul masinii in negativ pentru a nu mai aparea la vanzare
            // dar ca sa ramana in baza de date
            _context.Cars.Single(car => car.Id == insurance.CarId).Price = 0;
           
            // Adaugam id ul masini in lista userului
            var userInDb = _context.Customers.Single(customer => customer.CNP == insurance.CustomerCNP);
            List<int> userCars = (List<int>)userInDb.CarsId;
            
            if (userCars is null)
            {
                userCars = new List<int>();
            }

            userCars.Add(insurance.CarId);
            userInDb.CarsId = (IEnumerable<int>)userCars;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}