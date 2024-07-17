
using Microsoft.Extensions.Configuration;
using StudentManagement.Domain.Interfaces.Repository;
using StudentManagement.Domain.Models;
using StudentManagement.Infrastructure.Context;
using StudentManagement.Infrastructure.Repository.Base;


namespace StudentManagement.Infrastructure.Repository
{
    public class StudentRepository : RepositoryBase<StudentModel, long>, IStudentRepository
    {
        private StudentContext _context;

        public StudentRepository(
            StudentContext context,
            IConfiguration appSettings
            ) : base(context)
        {
            _context = context;
        }

    }
}
