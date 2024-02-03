using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL;

namespace UI.Models
{
    public class PolicyViewModel
    {
        [Required(ErrorMessage = "Policy Number is required")]
        public string PolicyNumber { get; set; }



        [Required(ErrorMessage = "Applied Date is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }

        public string Category { get; set; }
        public PolicyType PolicyType { get; set; }

        public double Price { get; set; }

    }


}