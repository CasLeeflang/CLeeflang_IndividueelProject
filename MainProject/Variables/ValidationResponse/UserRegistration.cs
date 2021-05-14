using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables.ValidationResponse
{
    public class UserRegistration
    {
        //  Object to store user registration validation
        public bool Valid { get; set; } = false;
        public bool UserNameError { get; set; }
        public bool EmailError { get; set; }
        public bool DoBError { get; set; } = false;
    }
}
