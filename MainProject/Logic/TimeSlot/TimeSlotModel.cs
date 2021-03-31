using FactoryDAL;
using Interface;
using Interface.TimeSlot;
using Models;
using System;

namespace Logic
{
    public class TimeSlotModel : ITimeSlot
    {
        public int Id { get; set; }
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

        public TimeSlotModel(int businessId, string dayOTWeek, DateTime startTime, DateTime endTime, int numberOfSpots)
        {
            BusinessId = businessId;
            DayOTWeek = dayOTWeek;
            StartTime = startTime;
            EndTime = endTime;
            NumberOfSpots = numberOfSpots;
        }

        public TimeSlotModel(TimeSlotDTO timeSlotDTO)
        {
            Id = timeSlotDTO.Id;
            BusinessId = timeSlotDTO.BusinessId;
            DayOTWeek = timeSlotDTO.DayOTWeek;
            StartTime = timeSlotDTO.StartTime;
            EndTime = timeSlotDTO.EndTime;
            NumberOfSpots = timeSlotDTO.NumberOfSpots;
        }

        public bool Validate()
        {
            if(TimeSpan.TotalMinutes > 0 && NumberOfSpots >= 0)
            {
                return true;
            }
            else { return false; }

            // Check other properties too
        }

        ITimeSlotDAL _timeSlotDAL = TimeSlotFactoryDAL.CreateTimeSlotDAL();
    }
}
