using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Variables.ValidationResponse;

namespace CLeeflang_IndividueelProject.Models.Date
{
    public class DateViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [ReservationDate(ErrorMessage = "Select a date later than today!")]
        [DateLTTwoWeeks(ErrorMessage = "Select a date no more than two weeks ahead!")]
        public DateTime Date { get; set; }
    }
}
