using FactoryDAL;
using Interface;
using Interface.TimeSlot;
using System;

namespace Logic
{
    public class TimeSlotModel : ITimeSlot
    {

        public int BusinessId { get; set; }
        public string DayOTWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfSpots { get; set; }


        public TimeSpan TimeSpan
        {
            get
            {
                return EndTime.TimeOfDay - StartTime.TimeOfDay;
            }

        }

        public TimeSlotModel(TimeSlotDTO timeSlotDTO)
        {
            this.BusinessId = timeSlotDTO.BusinessId;
            this.DayOTWeek = timeSlotDTO.DayOTWeek;
            this.StartTime = timeSlotDTO.StartTime;
            this.EndTime = timeSlotDTO.EndTime;
            this.NumberOfSpots = timeSlotDTO.NumberOfSpots;
        }

        ITimeSlotDAL timeSlotDAL = TimeSlotFactoryDAL.CreateTimeSlotDAL();
    }
}
