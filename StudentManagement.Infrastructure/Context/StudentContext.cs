using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Models;
using StudentManagement.Infrastructure.Map;
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
            // Configurações adicionais

            //var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            //{
            //    Delimiter = ";",
            //    HasHeaderRecord = true,
            //    Quote = '"',
            //    TrimOptions = TrimOptions.Trim,
            //};

            //using (var reader = new StreamReader(_csvFile))
            //using (var csv = new CsvReader(reader, config))
            //{
            //    csv.Context.RegisterClassMap<StudentMap>();
            //    var records = csv.GetRecords<StudentModel>().ToList();

            //    modelBuilder.Entity<StudentModel>().HasData(records);
            //}
        }
    }
}
