using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripPlan.Model.ThingstoDo;
using TripPlan.Services;

namespace TripPlan.WebMVC.Controllers
{
    [Authorize]
    public class ThingstoDoController : Controller
    {
        // GET: ThingstoDo
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ThingstoDoServices(userId);
            var model = service.GetThingstoDo();

            return View(model);
        }

        //ADD
        // GET
        public ActionResult create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(ThingsToDoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateThingsTodoService();

            if (service.CreateThingsToDo(model))
            {
                TempData["SaveResult"] = "Your Thing to do  was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Things to do  can not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {

            var svc = CreateThingsTodoService();
            var model = svc.GetThingsTodoById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateThingsTodoService();
            var detail = service.GetThingsTodoById(id);
            var model =
                new ThingsToDoEdit
                {
                    ThingsToDoId = detail.ThingsToDoId,
                    Activity = detail.Activity,
                    Description = detail.Description

                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ThingsToDoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ThingsToDoId != id)
            {
                ModelState.AddModelError("", "Id not match");
                return View(model);
            }
            var service = CreateThingsTodoService();

            if (service.UpdateThingsToDot(model))
            {
                TempData["SaveResult"] = "Your List of things to do was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your List of things to do can not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateThingsTodoService();
            var model = svc.GetThingsTodoById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateThingsTodoService();

            service.DeleteThingsTodo(id);

            TempData["SaveResult"] = ("Your Thing to do  was Deleted.");
            return RedirectToAction("Index");
        }

        private ThingstoDoServices CreateThingsTodoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ThingstoDoServices(userId);
            return service;
        }
    }
}