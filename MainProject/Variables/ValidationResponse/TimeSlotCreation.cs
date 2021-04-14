using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables.ValidationResponse
{
    public class TimeSlotCreation
    {
        public bool Valid { get; set; } = false;
        public bool TimeError { get; set; }
        public bool SpotError { get; set; }
    }
}
