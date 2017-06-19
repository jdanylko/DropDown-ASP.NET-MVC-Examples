using System.Collections.Generic;
using DropDownDemo.Models;

namespace DropDownDemo.ViewModels
{
    public class VehicleMakeModelComparer : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            var xKey = x.Make + " " + x.Model;
            var yKey = y.Make + " " + y.Model;

            return xKey.Equals(yKey);
        }

        public int GetHashCode(Vehicle obj)
        {
            var key = obj.Make + " " + obj.Model;
            return key.GetHashCode();
        }
    }
}