using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DropDownDemo.Models;
using DropDownDemo.Repository;

namespace DropDownDemo.Controllers
{
    public class HomeController : Controller
    {
        private MonthRepository _repository = new MonthRepository(
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