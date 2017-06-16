using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using DropDownDemo.Models;
using DropDownDemo.Repository;

namespace DropDownDemo
{
    public class VehiclesController : ApiController
    {
        [HttpGet]
        public Vehicle[] GetByYear(string id)
        {
            var connection = ConfigurationManager.ConnectionStrings["DropdownDatabase"].ToString();
            var repository = new VehicleRepository(connection);
            var records = repository.GetAll().Where(e => e.Year.ToString() == id);
            return records
                .Select(e => new Vehicle { Make = e.Make, Model = e.Model })
                .ToArray();
        }
    }
}