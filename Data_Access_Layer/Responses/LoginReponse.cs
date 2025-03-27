using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Responses
{
    public class LoginResponse
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
