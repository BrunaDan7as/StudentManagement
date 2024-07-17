using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentManagement.Application.Services;
using StudentManagement.Application.Services.Authentication;
using StudentManagement.Domain.Interfaces.Repository;
using StudentManagement.Domain.Interfaces.Services;
using StudentManagement.Infrastructure.Context;
using StudentManagement.Infrastructure.Repository;



namespace DependencyInjection
{
    public static class DependencyRegistration
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            RegisterDatas(services, configuration);
            RegisterRepositories(services);
            RegisterServices(services, configuration);
        }
        private static void RegisterDatas(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<StudentContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));  

        }
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IStudentRepository>(provider =>
            {
                var context = provider.GetRequiredService<StudentContext>();
                var appSettings = provider.GetRequiredService<IConfiguration>();
                return new StudentRepository(context, appSettings);
            });
        }
        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<JwtService>(provider =>
                new JwtService(null, provider.GetRequiredService<ILogger<JwtService>>(),configuration));
        }

    }
}
