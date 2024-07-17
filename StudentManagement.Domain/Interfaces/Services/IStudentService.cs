using StudentManagement.Domain.Models;

namespace StudentManagement.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        List<StudentModel> GetAllStudents();
        StudentModel AddStudent(StudentModel student);

        StudentModel Update(int id, StudentModel student);

        StudentModel Delete(int id);

        StudentModel GetStudent(int id);

    }
}
