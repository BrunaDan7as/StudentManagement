using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class JwtService
{
    private readonly RequestDelegate _next;
    private readonly ILogger<JwtService> _logger;
    private readonly IConfiguration _configuration;

    public JwtService(RequestDelegate next, ILogger<JwtService> logger, IConfiguration configuration)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task InvokeAsync(HttpContext context)
    {

        if (!context.Request.Path.Equals("/api/auth/login", StringComparison.OrdinalIgnoreCase))
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogInformation("Token JWT não encontrado na requisição ou no formato esperado.");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            try
            {
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                }, out SecurityToken validatedToken);


                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = jwtToken.Claims.First(x => x.Type == "sub").Value;

                context.Items["Admin"] = userId;
                await _next(context); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao validar o token JWT: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
        }
        else
        {
            await _next(context);
        }
    }
}
