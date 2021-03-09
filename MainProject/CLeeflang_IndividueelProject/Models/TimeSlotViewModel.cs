using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLeeflang_IndividueelProject.Models
{
    public class TimeSlotViewModel : ITimeSlotView
    {
        [Required]
        public int BusinessUserId { get; set; }

        [Required]
        public string DayOTWeek { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }

        [Required]
        public int NumberOfSpotsAvailable { get; set; }

    }
}
