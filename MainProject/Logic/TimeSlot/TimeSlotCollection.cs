using DAL.TimeSlot;
using FactoryDAL;
using Interface;
using Interface.TimeSlot;
using SQLDataAccess;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class TimeSlotCollection
    {
        ITimeSlotCollectionDAL _timeSlotCollectionDAL = TimeSlotFactoryDAL.CreateTimeSlotCollectionDAL();
        public void CreateTimeSlot(ITimeSlot newTimeSlot)
        {
            // map view model into DTO
            TimeSlotDTO newTimeSlotDTO = new TimeSlotDTO
            {
                BusinessId = newTimeSlot.BusinessId,
                DayOTWeek = newTimeSlot.DayOTWeek,
                StartTime = newTimeSlot.StartTime,
                EndTime = newTimeSlot.EndTime,
                NumberOfSpots = newTimeSlot.NumberOfSpots
            };

            _timeSlotCollectionDAL.CreateTimeSlot(newTimeSlotDTO);
        }

        public IEnumerable<TimeSlotModel> GetTimeSlotByBusinessId(int businessId)
        {
            // Load in the TimeSlotDTOs into ienumerable
            IEnumerable<TimeSlotDTO> timeSlotDTOs = _timeSlotCollectionDAL.LoadTimeSlotByBusinessId(businessId);

            // Initialise Logic model list
            List<TimeSlotModel> timeSlots = new List<TimeSlotModel>();

            // Map DTO to LogicModel
            foreach(var timeSlotDTO in timeSlotDTOs)
            {
                TimeSlotModel timeSlot = new TimeSlotModel(timeSlotDTO);
                timeSlots.Add(timeSlot);
            }
            

            return timeSlots;
        }
    }
}
