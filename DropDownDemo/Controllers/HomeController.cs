using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DropDownDemo.Models;
using DropDownDemo.Repository;
using DropDownDemo.ViewModels;

namespace DropDownDemo.Controllers
{
    public class HomeController : Controller
    {
        private MonthRepository _repository = new MonthRepository(
            ConfigurationManager.ConnectionStrings["DropdownDatabase"].ConnectionString);
        private VehicleRepository _vehicleRepository = new VehicleRepository(
            ConfigurationManager.ConnectionStrings["DropdownDatabase"].ConnectionString);

        public ActionResult Index()
        {
            // We only want a list of months in a single array.
            var model = new MonthViewModel
            {
                MonthData = _repository
                    .GetAll()
                    .Select(item => item.MonthName).ToArray()
            };

            return View(model);
        }

        public ActionResult WebGrid()
        {
            var model = new VehicleViewModel
            {
                AllVehicles = _vehicleRepository.GetAll()
            };
            // Grab the first year.
            var firstYear = model.GetVehicleYearSelectList(model.AllVehicles).First().Value;
            model.SelectedVehicles = model.AllVehicles.Where(e => e.Year.ToString() == firstYear);

            return View(model);
        }

        [HttpPost]
        public ActionResult WebGrid(VehicleViewModel model)
        {
            model.AllVehicles = _vehicleRepository.GetAll();
            model.SelectedVehicles = model.AllVehicles.Where(e => e.Year == model.SelectedYear);

            return View(model);
        }

        public ActionResult CascadingAllData()
        {
            var model = new VehicleViewModel
            {
                AllVehicles = _vehicleRepository.GetAll()
            };

            var firstYear = model.GetVehicleYearSelectList(model.AllVehicles).First().Value;
            model.SelectedVehicles = model.AllVehicles.Where(e => e.Year.ToString() == firstYear);
            model.SelectedYear = int.Parse(firstYear);

            return View(model);
        }


        public ActionResult CascadingSignalR()
        {
            var model = new VehicleViewModel
            {
                AllVehicles = _vehicleRepository.GetAll()
            };

            var firstYear = model.GetVehicleYearSelectList(model.AllVehicles).First().Value;
            model.SelectedVehicles = model.AllVehicles.Where(e => e.Year.ToString() == firstYear);
            model.SelectedYear = int.Parse(firstYear);

            return View(model);
        }

        public ActionResult CascadingWebAPI()
        {
            var model = new VehicleViewModel
            {
                AllVehicles = _vehicleRepository.GetAll()
            };

            var firstYear = model.GetVehicleYearSelectList(model.AllVehicles).First().Value;
            model.SelectedVehicles = model.AllVehicles.Where(e => e.Year.ToString() == firstYear);
            model.SelectedYear = int.Parse(firstYear);

            return View(model);
        }

        public ActionResult SuggestionDropdown()
        {
            return View();
        }

        public ActionResult GridDropdown()
        {
            return View();
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}