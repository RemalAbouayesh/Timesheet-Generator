using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardRockTimesheetsGenerator.Models;
using HardRockTimesheetsGenerator.Services;
using HardRockTimesheetsGenerator.Enums;

namespace HardRockTimesheetsGenerator.Controllers
{
    public class TimesheetsController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTimesheetsModel model)
        {
            try
            {
                //Check End date is greater than Start date
                if(model.EndDate<= model.StartDate)
                {
                    ModelState.AddModelError("EndDate", "End date should be greater than Start date");
                }

                //If invalid, return to view
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                return RedirectToAction("List", model);
            }

            catch (Exception exception)
            {
                //log exception
                ViewBag.ErrorMessage = "an error has occured, please try again later";
                return View(model);
            }
        }

        public ActionResult List(CreateTimesheetsModel createModel)
        {
            //Can use DI
            var timesheetsService = new TimesheetService();
            var timesheets = timesheetsService.GetTimesheets(createModel.StartDate, createModel.EndDate, createModel.PlacementType);

            var model = new ListTimesheetsModel()
            {
                CandidateName = createModel.CandidateName,
                ClientName = createModel.ClientName,
                JobTitle = createModel.JobTitle,
                PlacementTypeName = createModel.PlacementType == PlacementType.Weekly?"Week":"Month",
                Timesheets = timesheets
            };
            return View(model);
        }
    }
}