using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardRockTimesheetsGenerator.Enums;
using HardRockTimesheetsGenerator.Services.Entities;
using HardRockTimesheetsGenerator.Extensions;

namespace HardRockTimesheetsGenerator.Services
{
    public class TimesheetService
    {
        public IEnumerable<Timesheet> GetTimesheets(DateTime startDate, DateTime endDate, PlacementType placementType)
        {
            IEnumerable<Timesheet> timesheets = Enumerable.Empty<Timesheet>();

            //Weekly timesheets
            if (placementType == PlacementType.Weekly)
            {
                timesheets= Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
               .Select(offset => startDate.AddDays(offset))
               .GroupBy(d => d.GetWeekNumber())
               .Select(d => new Timesheet() { Number = d.Key, Days = d.ToList() });
            }

            //Monthly timesheets
            else if(placementType==PlacementType.Monthly)
            {
               timesheets = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
              .Select(offset => startDate.AddDays(offset))
              .GroupBy(d => d.Month)
              .Select(d => new Timesheet() { Number = d.Key, Days = d.ToList() });
            }
            return timesheets;
        }
    }
}