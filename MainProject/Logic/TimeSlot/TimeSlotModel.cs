using FactoryDAL;
using DTOs;
using System;
using Contract_Layer.TimeSlot;
using Variables.ValidationResponse;
using Logic.Reservation;
using System.Collections.Generic;

namespace Logic.TimeSlot
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

#nullable enable
        private int? NumberOfReservations { get; }
        public string? BusinessName { get; set; }
#nullable disable


        public TimeSpan TimeSpan
        {
            get
            {
                return EndTime.TimeOfDay - StartTime.TimeOfDay;
            }
        }

        public int? AvailableSpots
        {
            get
            {
                return NumberOfSpots - NumberOfReservations;
            }
        }

        public TimeSlotModel(int businessId, string dayOTWeek, DateTime startTime, DateTime endTime, int numberOfSpots)
        {            
            BusinessId = businessId;
            DayOTWeek = dayOTWeek;
            StartTime = new DateTime(9999, 01, 01) + startTime.TimeOfDay;   //  Removes the date from the datetime object
            EndTime = new DateTime(9999, 01, 01) + endTime.TimeOfDay;
            NumberOfSpots = numberOfSpots;
        }

        public TimeSlotModel(TimeSlotDTO timeSlotDTO)
        {
            Id = timeSlotDTO.Id;
            BusinessId = timeSlotDTO.BusinessId;
            BusinessName = timeSlotDTO.BusinessName;
            DayOTWeek = timeSlotDTO.DayOTWeek;
            StartTime = timeSlotDTO.StartTime;
            EndTime = timeSlotDTO.EndTime;
            NumberOfSpots = timeSlotDTO.NumberOfSpots;
            NumberOfReservations = timeSlotDTO.NumberOfReservations;
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
