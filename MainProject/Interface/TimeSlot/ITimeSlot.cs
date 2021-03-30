using System;

namespace Interface
    
{
    public interface ITimeSlot
    {
        int BusinessId { get; set; }
        string DayOTWeek { get; set; }
        DateTime EndTime { get; set; }
        DateTime StartTime { get; set; }
        int NumberOfSpots { get; set; }
    }
}