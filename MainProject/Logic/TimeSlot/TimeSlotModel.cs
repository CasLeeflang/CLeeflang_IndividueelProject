using FactoryDAL;
using DTOs;
using System;
using Contract_Layer.TimeSlot;
using Variables.ValidationResponse;

namespace Logic
{
    public class TimeSlotModel
    {

        ITimeSlotDAL _timeSlotDAL = TimeSlotFactoryDAL.CreateTimeSlotDAL();

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

        public void UpdateTimeSlot()
        {
            _timeSlotDAL.UpdateTimeSlot();
        }

        public TimeSlotCreation Validate()
        {
            TimeSlotCreation _creationValidation = new();

            if(TimeSpan.TotalMinutes < 1)
            {
                _creationValidation.TimeError = true;
            }
            if(NumberOfSpots <= 0)
            {
                _creationValidation.SpotError = true;
            }
            if(_creationValidation.TimeError == false && _creationValidation.SpotError == false)
            {
                _creationValidation.Valid = true;
            }
            return _creationValidation;         

        }

    }
}
