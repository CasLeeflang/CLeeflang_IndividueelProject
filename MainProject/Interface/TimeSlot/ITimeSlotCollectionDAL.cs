using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract_Layer.TimeSlot
{
    public interface ITimeSlotCollectionDAL
    {
        void CreateTimeSlot(TimeSlotDTO newTimeSlot);
        IEnumerable<TimeSlotDTO> GetTimeSlotByBusinessId(int businessId);
        IEnumerable<TimeSlotDTO> GetTimeSlotByDayAndBusinessId(DateTime date, string day, int businessId);
        IEnumerable<TimeSlotDTO> GetTimeSlotById(int id);
        void DeleteTimeSlot(int id);
    }
}
