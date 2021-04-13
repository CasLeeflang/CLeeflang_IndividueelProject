using Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLeeflang_IndividueelProject.Models
{
    public class TimeSlotViewModel
    {
        [Required]
        public int BusinessId { get; set; }

        [Required]
        public string DayOTWeek { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]        
        public int NumberOfSpots { get; set; }

    }
}
