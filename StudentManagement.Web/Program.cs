using CsvHelper.Configuration;
using CsvHelper;
using DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentManagement.Domain.Interfaces.Repository;
using StudentManagement.Domain.Models;
using StudentManagement.Infrastructure.Context;
using StudentManagement.Infrastructure.Map;
using StudentManagement.Infrastructure.Repository;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Students API", Version = "v1" });
});

builder.Services.AddCors();
builder.Services.AddControllers();
DependencyRegistration.RegisterDependencies(builder.Services, builder.Configuration);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("Jwt");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StudentContext>();
    var configuration = services.GetRequiredService<IConfiguration>();

    // Garante que o banco de dados seja criado e carrega os dados do CSV
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
        csv.Context.RegisterClassMap<StudentMap>(); // Substitua StudentMap pelo seu mapeamento de CSV
        var records = csv.GetRecords<StudentModel>().ToList();

        // Adicionar os registros ao contexto do banco de dados
        context.Students.AddRange(records);
        context.SaveChanges();
    }
}





// Habilita o Swagger e o Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    c.RoutePrefix = string.Empty; // Define a raiz do Swagger UI como a raiz do aplicativo
});


//using (var scope = app.Services.CreateScope())
//{
//    //var csvService = scope.ServiceProvider.GetRequiredService<StudentRepository>();
//    //csvService.LoadCsvDataIntoDatabase();
//    var studentRepository = scope.ServiceProvider.GetRequiredService<IStudentRepository>();
//    studentRepository.LoadCsvDataIntoDatabase();
//}
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");
});



app.Run();
