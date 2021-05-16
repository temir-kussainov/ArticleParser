using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class DateTimeFormatter
    {
        public static DateTime Format(string dateTimeStr, string dateTimeFormat)
        {
            DateTime dateTime = new DateTime();

            dateTimeStr = dateTimeStr.Trim()?
                .Replace("/n", "")
                .Replace("сегодня", DateTime.Now.Date.ToString(dateTimeFormat).Replace(", 00:00",""))
                .Replace("вчера", DateTime.Now.AddDays(-1).Date.ToString(dateTimeFormat).Replace(", 00:00", ""));

            if (DateTime.TryParseExact(dateTimeStr, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime outDateTime))
                dateTime = outDateTime;

            return dateTime;
        }
    }
}
