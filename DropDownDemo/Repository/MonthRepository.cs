using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using DropDownDemo.Models;

namespace DropDownDemo.Repository
{
    public class MonthRepository : AdoRepository<MonthItem>
    {
        public MonthRepository(string connectionString) 
            : base(connectionString) { }

        public IEnumerable<MonthItem> GetAll()
        {
            using (var command = new 
                SqlCommand("SELECT Id, Month FROM Months"))
            {
                return GetRecords(command);
            }
        }

        public MonthItem GetById(string id)
        {
            using (var command = new 
                SqlCommand("SELECT Id, Month FROM Months WHERE Id = @id"))
            {
                command.Parameters.Add(new ObjectParameter("id", id));
                return GetRecord(command);
            }
        }
        public override MonthItem PopulateRecord(SqlDataReader reader)
        {
            return new MonthItem
            {
                Id = reader.GetInt32(0),
                MonthName = reader.GetString(1)
            };
        }
    }
}