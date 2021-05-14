using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BusinessUserDTO
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public string Sector { get; set; }

        public BusinessUserDTO()
        {

        }
    }
}
