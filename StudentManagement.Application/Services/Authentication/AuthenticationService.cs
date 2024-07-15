using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.DataTransferObject.Authentication.Request;
using StudentManagement.DataTransferObject.Authentication.Response;
using StudentManagement.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        private IConfiguration _appSettings;

        public AuthenticationService(
            IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest model)
        {
            // Validação simples do usuário
            if (model.Username == "admin" && model.Password == "admin")
            {
                // Gerar o token JWT
                var token = GenerateJwtToken(model.Username);
                return new AuthenticationResponse
                {
                    Username = model.Username,
                    Token = token
                };
            }

            // Retornar null ou lançar uma exceção caso a autenticação falhe
            return null;
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _appSettings.GetSection("Jwt");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
