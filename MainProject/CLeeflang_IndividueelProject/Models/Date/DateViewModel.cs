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
        [ReservationDate(ErrorMessage = "Invalid date")]
        public DateTime Date { get; set; }
    }
}
