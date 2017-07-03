using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HardRockTimesheetsGenerator.Extensions
{
    public static class DatetimeExtensions
    {
        public static int GetWeekNumber(this DateTime datetime)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(datetime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }
    }
}