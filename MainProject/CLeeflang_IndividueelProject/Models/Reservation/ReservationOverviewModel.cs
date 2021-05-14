using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLeeflang_IndividueelProject.Models.Reservation
{
    public class ReservationOverviewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string BusinessName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
