using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using DropDownDemo.Models;

namespace DropDownDemo.Repository
{
    public class VehicleRepository : AdoRepository<Vehicle>
    {
        public VehicleRepository(string connectionString) 
            : base(connectionString) { }

        public IEnumerable<Vehicle> GetAll()
        {
            using (var command = new 
                SqlCommand("SELECT Id, Year, Make, Model FROM VehicleModelYear"))
            {
                return GetRecords(command);
            }
        }

        public Vehicle GetById(string id)
        {
            using (var command = new 
                SqlCommand("SELECT Id, Year, Make, Model FROM VehicleModelYear WHERE Id = @id"))
            {
                command.Parameters.Add(new ObjectParameter("id", id));
                return GetRecord(command);
            }
        }

        public IEnumerable<Vehicle> Search(string substring)
        {
            using (var command = new 
                SqlCommand("SELECT Id, Year, Make, Model FROM VehicleModelYear WHERE CHARINDEX(@partialStr, Make+' '+Model) > 0"))
            {
                command.Parameters.Add(new SqlParameter("partialStr", substring));
                return GetRecords(command);
            }
        }

        public override Vehicle PopulateRecord(SqlDataReader reader)
        {
            return new Vehicle
            {
                Id = reader.GetInt32(0),
                Year = reader.GetInt32(1),
                Make = reader.GetString(2),
                Model = reader.GetString(3)
            };
        }
    }
}