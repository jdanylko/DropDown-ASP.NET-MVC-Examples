using System.Collections.Generic;
using DropDownDemo.Models;

namespace DropDownDemo.ViewModels
{
    public class VehicleYearComparer : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            return x.Year.Equals(y.Year);
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.Year.GetHashCode();
        }
    }
}