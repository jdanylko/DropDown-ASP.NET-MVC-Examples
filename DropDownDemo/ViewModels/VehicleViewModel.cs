using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DropDownDemo.Models;

namespace DropDownDemo.ViewModels
{
    public class VehicleViewModel
    {
        public IEnumerable<Vehicle> AllVehicles { get; set; }

        public int SelectedYear { get; set; }

        public IEnumerable<Vehicle> SelectedVehicles { get; set; }

        public IEnumerable<SelectListItem> GetVehicleYearSelectList(IEnumerable<Vehicle> vehicles, int defaultYear = 0)
        {
            return vehicles
                .Distinct(new VehicleYearComparer())
                .OrderBy(e => e.Year)
                .Select((e, i) => new SelectListItem
                {
                    Text = e.Year.ToString(),
                    Value = e.Year.ToString(),
                    Selected = e.Year == defaultYear
                });
        }

        public IEnumerable<SelectListItem> GetVehicleMakeSelectList(IEnumerable<Vehicle> vehicles, int defaultYear = 0)
        {
            return vehicles
                .Where(auto => auto.Year == defaultYear)
                .OrderBy(e => e.Year)
                .ThenBy(auto => auto.Make)
                .Select((e, i) => new SelectListItem
                {
                    Text = $"{e.Make} {e.Model}",
                    Value = $"{e.Make} {e.Model}"
                });
        }
    }
}