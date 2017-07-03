using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardRockTimesheetsGenerator.Services.Entities
{
    public class Timesheet
    {
        public int Number { get; set; }
        public IEnumerable<DateTime> Days { get; set; }
    }
}