using StudentManagement.Domain.Interfaces.Repository.Base;
using StudentManagement.Domain.Models;

namespace StudentManagement.Domain.Interfaces.Repository
{
    public interface IStudentRepository : IRepositoryBase<StudentModel,long>
    {
    }
}
