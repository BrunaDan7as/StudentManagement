using StudentManagement.Domain.Interfaces.Repository;
using StudentManagement.Domain.Interfaces.Services;
using StudentManagement.Domain.Models;

namespace StudentManagement.Application.Services
{

    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentModel> GetAllStudents()
        {
            return _studentRepository.List().ToList();
        }

        public StudentModel GetStudent(int id)
        {
            return _studentRepository.GetBy(x=>x.Id==id);
        }

        public StudentModel AddStudent(StudentModel student)
        {
            _studentRepository.Add(student);
            return student;
        }

        public StudentModel Update(int id, StudentModel student)
        {
            var existingStudent = _studentRepository.GetBy(x => x.Id == id);
            if (existingStudent != null)
            {
                existingStudent.Nome = student.Nome;
                existingStudent.Idade = student.Idade;
                existingStudent.Serie = student.Serie;
                existingStudent.NotaMedia = student.NotaMedia;
                existingStudent.Endereco = student.Endereco;
                existingStudent.NomePai = student.NomePai;
                existingStudent.NomeMae = student.NomeMae;
                existingStudent.DataNascimento = student.DataNascimento;

                _studentRepository.Update(existingStudent);
            }
            return existingStudent;
        }

        public StudentModel Delete(int id)
        {
            var studentToDelete = _studentRepository.GetBy(x => x.Id == id);
            if (studentToDelete != null)
            {
                _studentRepository.Delete(studentToDelete);
            }
            return studentToDelete;
        }
    }
}
