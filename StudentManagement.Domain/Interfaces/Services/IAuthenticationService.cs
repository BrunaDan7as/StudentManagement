using StudentManagement.DataTransferObject.Authentication.Request;
using StudentManagement.DataTransferObject.Authentication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest model);

    }
}
