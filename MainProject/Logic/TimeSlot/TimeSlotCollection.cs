using FactoryDAL;
using Contract_Layer;
using DTOs;
using System;
using System.Collections.Generic;
using Contract_Layer.TimeSlot;

namespace Logic.TimeSlot
{
    public class TimeSlotCollection
    {
        ITimeSlotCollectionDAL _timeSlotCollectionDAL;

        public TimeSlotCollection()
        {
            _timeSlotCollectionDAL = TimeSlotFactoryDAL.CreateTimeSlotCollectionDAL();
        }

        public TimeSlotCollection(ITimeSlotCollectionDAL timeSlotCollectionDAL)
        {
            _timeSlotCollectionDAL = timeSlotCollectionDAL;
        }

        private List<TimeSlotModel> timeSlots { get; } = new List<TimeSlotModel>();

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
            IEnumerable<TimeSlotDTO> timeSlotDTOs = _timeSlotCollectionDAL.GetTimeSlotByBusinessId(businessId);

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


        public IEnumerable<TimeSlotModel> GetTimeSlotById(int id)
        {
            // Load in the TimeSlotDTOs into IEnumerable
            IEnumerable<TimeSlotDTO> timeSlotDTOs = _timeSlotCollectionDAL.GetTimeSlotById(id);

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

        public IEnumerable<TimeSlotModel> GetTimeSlotByDayAndBusinessId(DateTime date, string day, int businessId)
        {

            IEnumerable<TimeSlotDTO> timeSlotDTOs = _timeSlotCollectionDAL.GetTimeSlotByDayAndBusinessId(date, day, businessId);
            try
            {
                foreach (var timeslotDTO in timeSlotDTOs)
                {
                    TimeSlotModel timeSlot = new TimeSlotModel(timeslotDTO);
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
