using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLeeflang_IndividueelProject.Models.Reservation
{
    public class ReservationViewModel
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public int TimeSlotId { get; set; }
    }
}
