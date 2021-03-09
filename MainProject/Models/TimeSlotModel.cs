using System;

namespace Models
{
    public class TimeSlotModel : ITimeSlotModel
    {

        public int BusinessUserId { get; set; }
        public string DayOTWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int NumberOfSpotsAvailable { get; set; }

    }
}
