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

        // void UpdateTimeSlot();
        IEnumerable<TimeSlotDTO> LoadTimeSlotByBusinessId(int businessId);
        void DeleteTimeSlot(int id);
    }
}
