using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using StudentManagement.Domain.Interfaces.Repository;
using StudentManagement.Domain.Models;
using StudentManagement.Infrastructure.Context;
using StudentManagement.Infrastructure.Map;
using StudentManagement.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Repository
{
    public class StudentRepository : RepositoryBase<StudentModel, long>, IStudentRepository
    {
        private StudentContext _context;
        //private string _csvFile;
        public StudentRepository(
            StudentContext context,
            IConfiguration appSettings
            ) : base(context)
        {
            _context = context;
            //_csvFile = appSettings.GetConnectionString("CsvFilePath");
        }

        //public void LoadCsvDataIntoDatabase()
        //{
        //    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        //    {
        //        Delimiter = ";",
        //        HasHeaderRecord = true, 
        //        Quote = '"', 
        //        TrimOptions = TrimOptions.Trim, 
        //    };

        //    using (var reader = new StreamReader(_csvFile))
        //    using (var csv = new CsvReader(reader, config))
        //    {
        //        csv.Context.RegisterClassMap<StudentMap>();
        //        var records = csv.GetRecords<StudentModel>().ToList();

        //        _context.Students.AddRange(records);
        //        _context.SaveChanges();
        //    }
        //}
    }
}
