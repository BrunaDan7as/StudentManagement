
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Models;
using Microsoft.Extensions.Configuration;
namespace StudentManagement.Infrastructure.Context
{
    public class StudentContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        private string _csvFile; 
        public StudentContext(DbContextOptions<StudentContext> options, IConfiguration appSettings) : base(options)
        {
            _csvFile = appSettings.GetConnectionString("CsvFilePath");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
