using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentManagement.Application.Services;
using StudentManagement.DataTransferObject.Student.Request;
using StudentManagement.Domain.Interfaces.Services;
using StudentManagement.Domain.Models;
using StudentManagement.Web.Controllers.Student;

namespace StudentManagement.Tests
{
    public class StudentModelTests
    {
        [Fact]
        public void DefinirObterPropriedadesCorretamente()
        {
            
            var student = new StudentModel();
            var nome = "Teste";
            var idade = 22;
            var serie = 9;
            var notaMedia = 9.5;
            var endereco = "Rio de Janeiro";
            var nomePai = "Teste Pai";
            var nomeMae = "Teste Mãe";
            var dataNascimento = new DateTime(1999, 7, 16);

            student.Nome = nome;
            student.Idade = idade;
            student.Serie = serie;
            student.NotaMedia = notaMedia;
            student.Endereco = endereco;
            student.NomePai = nomePai;
            student.NomeMae = nomeMae;
            student.DataNascimento = dataNascimento;

            Assert.Equal(nome, student.Nome);
            Assert.Equal(idade, student.Idade);
            Assert.Equal(serie, student.Serie);
            Assert.Equal(notaMedia, student.NotaMedia);
            Assert.Equal(endereco, student.Endereco);
            Assert.Equal(nomePai, student.NomePai);
            Assert.Equal(nomeMae, student.NomeMae);
            Assert.Equal(dataNascimento, student.DataNascimento);
        }
    }

    public class StudentControllerTests
    {
        private readonly Mock<IStudentService> _mockStudentService;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
            _controller = new StudentController(_mockStudentService.Object);
        }

        [Fact]
        public void GetAllEstudantes()
        {

            var students = new List<StudentModel>
            {
                new StudentModel
                {
                    Nome = "Bruna Dantas",
                    Idade = 25,
                    Serie = 3,
                    NotaMedia = 9.5,
                    Endereco = "Rua Exemplo, 123",
                    NomePai = "Pai Exemplo",
                    NomeMae = "Mãe Exemplo",
                    DataNascimento = new DateTime(1999, 7, 16)
                },
                new StudentModel
                {
                    Nome = "Rebecca Armstrong",
                    Idade = 30,
                    Serie = 5,
                    NotaMedia = 8.5,
                    Endereco = "Avenida Exemplo, 456",
                    NomePai = "Pai Armstrong",
                    NomeMae = "Mãe Armstrong",
                    DataNascimento = new DateTime(1994, 1, 1)
                }
            };
            _mockStudentService.Setup(s => s.GetAllStudents()).Returns(students);

            var result = _controller.GetAllStudents() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(students, result.Value);
        }

        [Fact]
        public void GetEstudanteById()
        {

            var studentId = 1; // ID fictício

            var expectedStudentModel = new StudentModel
            {
                Id = studentId,
                Nome = "Bruna Dantas",
                Idade = 25,
                Serie = 3,
                NotaMedia = 9.5,
                Endereco = "Rua Exemplo, 123",
                NomePai = "Pai Exemplo",
                NomeMae = "Mãe Exemplo",
                DataNascimento = new DateTime(1999, 7, 16)
            };

            _mockStudentService.Setup(s => s.GetStudent(studentId)).Returns(expectedStudentModel);

            var _controller = new StudentController(_mockStudentService.Object);

            var result = _controller.GetStudent(studentId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var returnedStudent = result.Value as StudentModel;
            Assert.NotNull(returnedStudent);

        }

        [Fact]
        public void addEstudante()
        {

            var studentRequest = new StudentRequest
            {
                Nome = "Bruna Dantas",
                Idade = 25,
                Serie = 3,
                NotaMedia = 9.5,
                Endereco = "Rua Exemplo, 123",
                NomePai = "Pai Exemplo",
                NomeMae = "Mãe Exemplo",
                DataNascimento = new DateTime(1999, 7, 16)
            };

            var studentModel = new StudentModel
            {
                Id = 1,
                Nome = studentRequest.Nome,
                Idade = studentRequest.Idade,
                Serie = studentRequest.Serie,
                NotaMedia = studentRequest.NotaMedia,
                Endereco = studentRequest.Endereco,
                NomePai = studentRequest.NomePai,
                NomeMae = studentRequest.NomeMae,
                DataNascimento = studentRequest.DataNascimento
            };

            _mockStudentService.Setup(s => s.AddStudent(It.IsAny<StudentModel>())).Returns(studentModel);

            var _controller = new StudentController(_mockStudentService.Object);

            var result = _controller.addStudent(studentRequest);

            Assert.NotNull(result); 
            Assert.IsType<CreatedAtActionResult>(result); 

            var createdAtResult = result as CreatedAtActionResult;
            Assert.Equal("students", createdAtResult.ActionName); 

            var returnedStudentModel = createdAtResult.Value as StudentModel;
            Assert.NotNull(returnedStudentModel); 

            // Comparando propriedades por garantia
            Assert.Equal(studentModel.Id, returnedStudentModel.Id);
            Assert.Equal(studentModel.Nome, returnedStudentModel.Nome);
            Assert.Equal(studentModel.Idade, returnedStudentModel.Idade);
            Assert.Equal(studentModel.Serie, returnedStudentModel.Serie);
            Assert.Equal(studentModel.NotaMedia, returnedStudentModel.NotaMedia);
            Assert.Equal(studentModel.Endereco, returnedStudentModel.Endereco);
            Assert.Equal(studentModel.NomePai, returnedStudentModel.NomePai);
            Assert.Equal(studentModel.NomeMae, returnedStudentModel.NomeMae);
            Assert.Equal(studentModel.DataNascimento, returnedStudentModel.DataNascimento);
        }

        

        [Fact]
        public void UpdateEstudante()
        {
            var studentId = 1; // ID fictício 
       
            var studentModel = new StudentModel
            {
                Id = studentId,
                Nome = "Bruna Dantas",
                Idade = 25,
                Serie = 3,
                NotaMedia = 9.5,
                Endereco = "Rua Exemplo, 123",
                NomePai = "Pai Exemplo",
                NomeMae = "Mãe Exemplo",
                DataNascimento = new DateTime(1999, 7, 16)
            };

            var studentRequest = new StudentRequest
            {
                Nome = studentModel.Nome,
                Idade = studentModel.Idade,
                Serie = studentModel.Serie,
                NotaMedia = studentModel.NotaMedia,
                Endereco = studentModel.Endereco,
                NomePai = studentModel.NomePai,
                NomeMae = studentModel.NomeMae,
                DataNascimento = studentModel.DataNascimento
            };

            _mockStudentService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<StudentModel>()))
                   .Returns((int id, StudentModel student) =>
                   {

                       if (id == studentId && student != null)
                       {

                           return studentModel;
                       }
                       else
                       {

                           return null; 
                       }
                   });

            var _controller = new StudentController(_mockStudentService.Object);

            var result = _controller.UpdateStudent(studentId, studentRequest);

            Assert.NotNull(result); 

            Assert.True(result is OkObjectResult || result is NoContentResult);

            if (result is OkObjectResult okObjectResult)
            {
                Assert.Equal(studentModel, okObjectResult.Value); 
            }
        }

        [Fact]
        public void DeleteEstudante()
        {

            var studentId = 1; // ID fictício

            var deletedStudent = new StudentModel
            {
                Id = studentId
            };

            _mockStudentService.Setup(s => s.Delete(It.IsAny<int>()))
                               .Returns(deletedStudent);

            var _controller = new StudentController(_mockStudentService.Object);

            var result = _controller.DeleteStudent(studentId);

            Assert.NotNull(result); 
            Assert.IsType<NoContentResult>(result); 
        }

         
    }
}