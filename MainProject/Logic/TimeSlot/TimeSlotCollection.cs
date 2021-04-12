using FactoryDAL;
using Interface;
using Interface.TimeSlot;
using Models;
using SQLDataAccess;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class TimeSlotCollection
    {
        ITimeSlotCollectionDAL _timeSlotCollectionDAL = TimeSlotFactoryDAL.CreateTimeSlotCollectionDAL();

        private List<TimeSlotModel> timeSlots { get;} = new List<TimeSlotModel>();

        public void CreateTimeSlot(TimeSlotModel newTimeSlot)
        {
            // map Logic model to DTO
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
            // Load in the TimeSlotDTOs into IEnumerable
            IEnumerable<TimeSlotDTO> timeSlotDTOs = _timeSlotCollectionDAL.LoadTimeSlotByBusinessId(businessId);

            // Map DTO to LogicModel and put into collection list
            try
            {
                foreach (var timeSlotDTO in timeSlotDTOs)
                {
                    TimeSlotModel timeSlot = new TimeSlotModel(timeSlotDTO);
                    timeSlots.Add(timeSlot);
                } 
                return timeSlots;
            }
            catch
            {
                return timeSlots;
            }            
        }

        public void DeleteTimeSlot(int id)
        {
            _timeSlotCollectionDAL.DeleteTimeSlot(id);
        }
    }
}
