using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables.ValidationResponse
{
    public class BusinessRegistration
    {
        //  Object to store Business user registration validation
        public bool Valid { get; set; } = false;
        public bool BusinessNameError { get; set; }
        public bool UserNameError { get; set; }
        public bool EmailError { get; set; }

    }
}
