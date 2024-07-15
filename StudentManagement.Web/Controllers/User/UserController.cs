﻿
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataTransferObject.Authentication.Request;
using StudentManagement.Domain.Interfaces.Services;
using System.Reflection;

namespace StudentManagement.Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest authenticationRequest)
        {
            var response = _authenticationService.Authenticate(authenticationRequest);

            if (response == null)
                return Unauthorized(new { message = "Dados Incorretos" });

            return Ok(response);
        }
    }
}