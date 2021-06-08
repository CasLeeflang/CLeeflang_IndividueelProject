using Contract_Layer.TimeSlot;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDAL
{
    public class TestTimeSlotDAL: ITimeSlotCollectionDAL, ITimeSlotDAL
    {
        public List<TimeSlotDTO> TimeSlotStorage { get; private set; } = new List<TimeSlotDTO>();

        public List<TimeSlotDTO> TempStorage { get; private set; } = new List<TimeSlotDTO>();

        public void CreateTimeSlot(TimeSlotDTO timeSlot)
        {
            TimeSlotStorage.Add(timeSlot);
        }

        public IEnumerable<TimeSlotDTO> GetTimeSlotByBusinessId(int businessId)
        {
            TempStorage.Add(TimeSlotStorage.FirstOrDefault(o => o.BusinessId == businessId));
            return TempStorage;
        }

        public IEnumerable<TimeSlotDTO> GetTimeSlotByDayAndBusinessId(DateTime date, string day, int businessId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeSlotDTO> GetTimeSlotById(int id)
        {
            TempStorage.Add(TimeSlotStorage.FirstOrDefault(o => o.Id == id));
            return TempStorage;
        }

        public void DeleteTimeSlot(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTimeSlot()
        {
            throw new NotImplementedException();
        }
    }
}
