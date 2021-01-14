using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoTavex.Models;
using AutoTavex.ViewModels;

namespace AutoTavex.Controllers
{
    public class MotoController : Controller
    {
        DatabaseContext _context;
        public MotoController()
        {
            _context = new DatabaseContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Moto
        public ActionResult Index()
        {
            var moto = _context.Moto;
            if (User.IsInRole(RoleName.CanManageVehicles))
            {
                return View("List", moto);
            }

            return View("ReadOnlyList", moto);
        }

        [Route("Moto/Add/")]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Add()
        {
            var viewModel = new MotoFormViewModel(0);
            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Moto moto, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                // Daca modelul nu e valid ne intoarcem pe pagina
                var viewModel = new MotoFormViewModel
                {
                    Title = CarFormViewmodel.Add,
                    Moto = moto
                };

                if (moto.Id > 0)
                {
                    viewModel.Title = CarFormViewmodel.Edit;
                }

                return View("Form", viewModel);
            }

            if (image != null)
            {
                string imagePath = "~\\Content\\Images\\" + image.FileName;
                image.SaveAs(HttpContext.Server.MapPath(imagePath));
                moto.Image = imagePath;
            }

            if (moto.Image != null && moto.Image[0] != '~')
            {
                string path = "~\\Content\\Images\\" + moto.Image.ToString();
                moto.Image = path;
            }

            if (moto.Id == 0)
            {
                // Daca masina este nou adaugata o introducem in Db
                _context.Moto.Add(moto);
            }
            else
            {
                // Daca masina este editata o updatam in Db
                var motoInDb = _context.Moto.Single(m => m.Id == moto.Id);
                motoInDb.Id = moto.Id;
                motoInDb.Manufacturer = moto.Manufacturer;
                motoInDb.Series = moto.Series;
                motoInDb.Vin = moto.Vin;
                motoInDb.CylindricalCapacity = moto.CylindricalCapacity;
                motoInDb.HorsePower = moto.HorsePower;
                motoInDb.YearManufactured = moto.YearManufactured;
                motoInDb.Caroserie = moto.Caroserie;
                motoInDb.Image = "~\\Content\\Images\\" + moto.Image;
                motoInDb.ExtraDetails = moto.ExtraDetails;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Doar pt admin
        [Route("Moto/Edit/{id}")]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Edit(int id)
        {
            var moto = _context.Moto.SingleOrDefault(m => m.Id == id);

            if (moto == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MotoFormViewModel
            {
                Title = CarFormViewmodel.Edit,
                Moto = moto
            };

            return View("Form", viewModel);
        }

        [Route("Moto/Delete/{id}")]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Delete(int id)
        {
            var moto = _context.Moto.SingleOrDefault(m => m.Id == id);
            _context.Moto.Remove(moto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Route("Moto/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            var moto = _context.Moto.SingleOrDefault(c => c.Id == id);


            return View(moto);
        }
    }
}