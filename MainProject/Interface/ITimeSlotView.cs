namespace CLeeflang_IndividueelProject.Models
{
    public interface ITimeSlotView
    {
        int BusinessUserId { get; set; }
        string DayOTWeek { get; set; }
        string EndTime { get; set; }
        string StartTime { get; set; }
        int NumberOfSpotsAvailable { get; set; }
    }
}