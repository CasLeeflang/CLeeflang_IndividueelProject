using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables.ValidationResponse
{
    public class ReservationValidation
    {
        public bool Valid { get; set; } = false;    
        public bool ExistsForUser { get; set; }
    }
}
