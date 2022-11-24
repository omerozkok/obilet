using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using obilet.Business.Abstract;
using obilet.Entities.Model.Journey;
using obilet.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace obilet.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBusLocationService _busLocationService;
        private IBusJourneyService _busJourneyService;

        public HomeController(ILogger<HomeController> logger, IBusLocationService busLocationService, IBusJourneyService busJourneyService)
        {
            _logger = logger;
            _busLocationService = busLocationService;
            _busJourneyService = busJourneyService;
        }

        [Authorize]
        public  IActionResult Index()
        {
            var result = _busLocationService.GetBusLocations();
            ViewBag.BusLocationList = new SelectList(result, "Id", "Name");
            return View();
        }

        [Authorize]
        public ActionResult FindJourney(BusJourneyRequestModel model)
        {
            ViewBag.DateStr = model.departureDate.ToLongDateString();
            var result = _busJourneyService.GetBusJourneys(model);            
            return View(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
