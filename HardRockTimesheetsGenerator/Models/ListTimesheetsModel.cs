using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardRockTimesheetsGenerator.Services.Entities;

namespace HardRockTimesheetsGenerator.Models
{
    public class ListTimesheetsModel
    {
        public string ClientName { get; set; }

        public string CandidateName { get; set; }

        public string JobTitle { get; set; }

        public string PlacementTypeName { get; set; }

        public IEnumerable<Timesheet> Timesheets { get; set; }
    }
}