using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripPlan.Model.RentACar;
using TripPlan.Services;

namespace TripPlan.WebMVC.Controllers
{
    [Authorize]
    public class RentACarController : Controller
    {
        // GET: RentACar
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RentACarServices(userId);
            var model = service.GetRentACar();

            return View(model);
        }

        //ADD
        // GET
        public ActionResult create()
        {

            return View();
        }

        //ADD
        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(RentACarCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRentACarService();

            if (service.CreateRentACar(model))
            {
                TempData["SaveResult"] = ("Your car was created");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "car can not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {

            var svc = CreateRentACarService();
            var model = svc.GetRentACarById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRentACarService();
            var detail = service.GetRentACarById(id);
            var model =
                new RentACarEdit
                {
                    RentACarId = detail.RentACarId,
                    CarName = detail.CarName,
                    Year = detail.Year

                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RentACarEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RentACarId != id)
            {
                ModelState.AddModelError("", "Id not match");
                return View(model);
            }
            var service = CreateRentACarService();

            if (service.UpdateRentACar(model))
            {
                TempData["SaveResult"] = ("Your car was updated.");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your car can not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRentACarService();
            var model = svc.GetRentACarById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRentACarService();

            service.DeleteRentACar(id);

            TempData["SaveResult"] = ("Your car  was Deleted.");
            return RedirectToAction("Index");
        }

        private RentACarServices CreateRentACarService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RentACarServices(userId);
            return service;
        }
    }
}