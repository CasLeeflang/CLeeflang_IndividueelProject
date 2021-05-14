using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLeeflang_IndividueelProject.Models.Reservation
{
    public class ReservationViewModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BusinessId { get; set; }

        [Required]
        public int TimeSlotId { get; set; }
    }
}
