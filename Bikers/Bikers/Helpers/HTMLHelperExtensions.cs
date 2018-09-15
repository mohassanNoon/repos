using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bikers.Helpers
{
    public static class HTMLHelperExtensions
    {
        public static string ShowDate(this HtmlHelper html, DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return datetime.Value.ToString("dddd, dd MMMM yyyy");
            }
            else
            {
                return "Not Updated";
            }
        }

    }
}