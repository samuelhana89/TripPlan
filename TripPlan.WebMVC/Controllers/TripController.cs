using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripPlan.Model.Trip;
using TripPlan.Services;

namespace TripPlan.WebMVC.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripServices(userId);
            var model = service.GetTrips();

            return View(model);
        }


        //Add
        //Get
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TripCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTripService();

            if (service.CreateTrip(model))
            {
                TempData["SaveResult"] = "Your trip was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Trip can not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTripService();
            var model = svc.GetTripById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTripService();
            var detail = service.GetTripById(id);
            var model =
                new TripEdit
                {
                    TripId = detail.TripId,
                    TripName = detail.TripName,
                    DestinationCity = detail.DestinationCity,
                    Description = detail.Description,
                    StartDate = detail.StartDate
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TripEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TripId != id)
            {
                ModelState.AddModelError("", "Id not match");
                return View(model);
            }
            var service = CreateTripService();

            if (service.UpdateTrip(model))
            {
                TempData["SaveResult"] = "Your trip was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Trip can not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTripService();
            var model = svc.GetTripById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTripService();

            service.DeleteTrip(id);

            TempData["SaveResult"] = ("Your trip was Deleted.");
            return RedirectToAction("Index");
        }

        private TripServices CreateTripService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripServices(userId);
            return service;
        }
    }
}