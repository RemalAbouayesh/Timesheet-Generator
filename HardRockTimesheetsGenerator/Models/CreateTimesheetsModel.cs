using HardRockTimesheetsGenerator.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardRockTimesheetsGenerator.Models
{
    public class CreateTimesheetsModel
    {
        [Required(ErrorMessage ="Please enter Client name")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Please enter Candidate name")]
        public string CandidateName { get; set; }

        [Required(ErrorMessage = "Please enter Job title")]
        public string JobTitle { get; set; }

        [Display(Name ="Start date")]
        [Required(ErrorMessage = "Please enter Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [Required(ErrorMessage = "Please enter End date")]
        public DateTime EndDate { get; set; }

        [Range(1,2,ErrorMessage = "Please select Placement type")]
        public PlacementType PlacementType { get; set; }
    }
}