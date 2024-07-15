using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.Services;
using StudentManagement.Domain.Interfaces.Repository;
using StudentManagement.Domain.Interfaces.Services;
using StudentManagement.Infrastructure.Context;
using StudentManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            //services.AddScoped<IConnectionFactory, SqlServerConnectionFactory>(x => new SqlServerConnectionFactory(configuration["ConnectionStrings:SqlServer"]));
            services.AddDbContext<StudentContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

            //services.AddDbContext<Data.AppContext>(options =>
            // options.UseSqlServer(
            //     configuration.GetConnectionString("ConnectionStrings:DevConnection")));

            //Register dapper in scope    

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
        }

    }
}
