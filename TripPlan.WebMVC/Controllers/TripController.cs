using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripPlan.Model.Trip;

namespace TripPlan.WebMVC.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            var model = new TripListItem[0];
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
        public ActionResult Create( TripCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}