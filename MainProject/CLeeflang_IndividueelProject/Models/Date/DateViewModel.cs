using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLeeflang_IndividueelProject.Models.Date
{
    public class DateViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
