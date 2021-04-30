using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables.ValidationResponse
{
    public class DateLTTwoWeeksAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);

            bool v = d.Date <= DateTime.Now.AddDays(14);
            return d.Date <= DateTime.Now.AddDays(14);

        }
    }
}
