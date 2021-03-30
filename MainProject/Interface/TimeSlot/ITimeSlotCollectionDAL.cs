using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.TimeSlot
{
    public interface ITimeSlotCollectionDAL
    {
        void CreateTimeSlot(TimeSlotDTO newTimeSlot);
        IEnumerable<TimeSlotDTO> LoadTimeSlotByBusinessId(int businessId);

        void DeleteTimeSlot();
    }
}
