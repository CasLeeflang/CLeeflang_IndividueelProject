using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TimeSlotDTO
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }

        public string DayOTWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfSpots { get; set; }

#nullable enable
        public string? BusinessName { get; set; }
        public int? NumberOfReservations { get; set; }
#nullable disable


        public TimeSlotDTO()
        {

        }
    }
}
