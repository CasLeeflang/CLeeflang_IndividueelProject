using System;

namespace Models
{
    public class TimeSlotModel : ITimeSlot
    {

        public int BusinessId { get; set; }
        public string DayOTWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeSpan
        {
            get
            {
                return EndTime.TimeOfDay - StartTime.TimeOfDay;
            }

        }
        public int NumberOfSpots { get; set; }

    }
}
