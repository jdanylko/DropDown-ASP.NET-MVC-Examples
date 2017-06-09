using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DropDownDemo.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> list, Func<T, string> dataField,
            Func<T, string> valueField, string defaultValue)
        {
            var result = new List<SelectListItem>();
            if (list.Any())
                result.AddRange(
                    list.Select(
                        resultItem => new SelectListItem
                        {
                            Value = valueField(resultItem),
                            Text = dataField(resultItem),
                            Selected = defaultValue == valueField(resultItem)
                        }));
            return result;
        }
    }
}