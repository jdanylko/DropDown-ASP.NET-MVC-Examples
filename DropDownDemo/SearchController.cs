using System.Configuration;
using System.Linq;
using System.Web.Http;
using DropDownDemo.Models;
using DropDownDemo.Repository;
using DropDownDemo.ViewModels;

namespace DropDownDemo
{
    public class SearchController : ApiController
    {
        [HttpGet]
        public Vehicle[] For(string id)
        {
            var connection = ConfigurationManager.ConnectionStrings["DropdownDatabase"].ToString();
            var repository = new VehicleRepository(connection);
            var records = repository.Search(id);
            return records
                .Distinct(new VehicleMakeModelComparer())
                .Select(e => new Vehicle { Make = e.Make, Model = e.Model })
                .OrderBy(e=> e.Make)
                .ThenBy(e=> e.Model)
                .Take(10)
                .ToArray();
        }
    }
}