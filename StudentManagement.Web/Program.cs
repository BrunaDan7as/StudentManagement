using CsvHelper.Configuration;
using CsvHelper;
using DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentManagement.Domain.Models;
using StudentManagement.Infrastructure.Context;
using StudentManagement.Infrastructure.Map;
using System.Globalization;
using System.Text;
using Leader.Integration.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();

DependencyRegistration.RegisterDependencies(builder.Services, builder.Configuration);

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt")
                                                       .GetSection("Key").Value);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Students API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {

        Description = @"JWT Authorization está utilizando o Bearer
                      Escreva Bearer [espaço] [token]
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",

        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Bearer", policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
    };
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StudentContext>();
    var configuration = services.GetRequiredService<IConfiguration>();

    // Garante que o banco de dados seja criado e carrega os dados do CSV (Readme)
    context.Database.EnsureCreated();

    var csvFile = configuration.GetConnectionString("CsvFilePath");

    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";",
        HasHeaderRecord = true,
        Quote = '"',
        TrimOptions = TrimOptions.Trim,
    };

    using (var reader = new StreamReader(csvFile))
    using (var csv = new CsvReader(reader, config))
    {
        csv.Context.RegisterClassMap<StudentMap>(); 
        var records = csv.GetRecords<StudentModel>().ToList();

        context.Students.AddRange(records);
        context.SaveChanges();
    }
}



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Students API v1");
    c.RoutePrefix = string.Empty;
});

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseMiddleware<JwtService>();
app.UseMiddleware<ValidationMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");
});

app.Run();
