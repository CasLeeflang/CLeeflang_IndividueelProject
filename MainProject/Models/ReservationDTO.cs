using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public int TimeSlotId { get; set; }
#nullable enable
        public bool CheckedIn { get; set; }
        public string? BusinessName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
#nullable disable
    }
}
