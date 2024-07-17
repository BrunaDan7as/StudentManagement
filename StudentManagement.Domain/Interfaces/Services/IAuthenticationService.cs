using StudentManagement.DataTransferObject.Authentication.Request;
using StudentManagement.DataTransferObject.Authentication.Response;

namespace StudentManagement.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest model);

    }
}
