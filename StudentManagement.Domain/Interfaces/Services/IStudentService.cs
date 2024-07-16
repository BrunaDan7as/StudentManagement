using StudentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
