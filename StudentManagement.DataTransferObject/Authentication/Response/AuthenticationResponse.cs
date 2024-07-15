using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataTransferObject.Authentication.Response
{
    public class AuthenticationResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
