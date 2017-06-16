using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using DropDownDemo.Models;
using DropDownDemo.Repository;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DropDownDemo.Hubs
{
    [HubName("autoHub")]
    public class AutoHub : Hub
    {
        public Task<IEnumerable<Vehicle>> GetAutosByYear(string year)
        {
            var connection = ConfigurationManager.ConnectionStrings["DropdownDatabase"].ToString();
            var repository = new VehicleRepository(connection);
            var taskResult = repository.GetAll().Where(auto => auto.Year.ToString() == year);

            var result = taskResult.Select(auto => new Vehicle {Make = auto.Make, Model = auto.Model});

            return Clients.Caller.updateMakeModel(result);
        }
    }
}