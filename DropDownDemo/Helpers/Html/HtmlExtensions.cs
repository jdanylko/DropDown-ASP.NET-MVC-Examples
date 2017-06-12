using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using DropDownDemo.Models;

namespace DropDownDemo.Helpers.Html
{
    public static class HtmlExtensions
    {
        public static HtmlString RatingDropDown(this HtmlHelper helper, Vehicle vehicle)
        {
            var ratings = GetRatingList(vehicle.Rating);

            var formatName = HtmlHelper.GenerateIdFromName(nameof(vehicle.Rating));
            var uniqueId = $"{formatName}_{vehicle.Id}";
            var input = helper.DropDownList(uniqueId, ratings, new { @class = "input-sm" });

            return new HtmlString(input.ToString());
        }

        private static IEnumerable<SelectListItem> GetRatingList(int vehicleRating)
        {
            var ratings = new List<SelectListItem>
            {
                new SelectListItem {Text = "1 - Poor", Value = "1"},
                new SelectListItem {Text = "2 - Fair", Value = "2"},
                new SelectListItem {Text = "3 - Good", Value = "3"},
                new SelectListItem {Text = "4 - Great", Value = "4"},
                new SelectListItem {Text = "5 - Excellent", Value = "5"}
            };
            ratings.ForEach(e=> e.Selected = vehicleRating.ToString() == e.Value);

            return ratings;
        }
    }
}