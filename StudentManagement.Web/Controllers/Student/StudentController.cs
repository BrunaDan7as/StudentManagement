
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataTransferObject.Student.Request;
using StudentManagement.Domain.Authorization;
using StudentManagement.Domain.Interfaces.Services;
using StudentManagement.Domain.Models;
namespace StudentManagement.Web.Controllers.Student
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Obter todos os estudantes
        /// </summary>
        /// <returns> Coleção de estudantes</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet("students")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        public IActionResult GetAllStudents()
        {
            var response = _studentService.GetAllStudents();
            return Ok(response);
        }

        /// <summary>
        /// Obter um estudante
        /// </summary>
        /// <param name="id">Identificador do estudante</param>
        /// <returns>Dados do estudante</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("students/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStudent(int id)
        {
            var response = _studentService.GetStudent(id);

            if (response == null)
            {
                return NotFound(new { message = "Dados não encontrados" });
            }

            return Ok(response);
        }

        /// <summary>
        /// Cadastrar um estudante
        /// </summary>
        /// <returns>Estudante criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">BadRequest</response>
        [HttpPost("students")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult addStudent(StudentRequest request)
        {
            try
            {
                var newStudent = new StudentModel
                {
                    Nome = request.Nome,
                    Idade = request.Idade,
                    Serie = request.Serie,
                    NotaMedia = request.NotaMedia,
                    Endereco = request.Endereco,
                    NomePai = request.NomePai,
                    NomeMae = request.NomeMae,
                    DataNascimento = request.DataNascimento
                };

                var createdStudent = _studentService.AddStudent(newStudent);

                return CreatedAtAction("students", new { id = createdStudent.Id }, createdStudent);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro na inserção: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualizar um estudante
        /// </summary>
        /// <param name="id">Identificador do estudante</param>
        /// <returns>Nada.</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("students/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateStudent(int id,StudentRequest request)
        {
            var updateStudent = new StudentModel();
            updateStudent.Nome = request.Nome;
            updateStudent.Idade = request.Idade;
            updateStudent.Serie = request.Serie;
            updateStudent.NotaMedia = request.NotaMedia;
            updateStudent.Endereco = request.Endereco;
            updateStudent.NomePai = request.NomePai;
            updateStudent.NomeMae = request.NomeMae;
            updateStudent.DataNascimento = request.DataNascimento;
            var response = _studentService.Update(id, updateStudent);

            if (response == null)
            {
                return NotFound(new { message = "Dados não encontrados" });
            }

            return NoContent();
        }

        /// <summary>
        /// Deletar um estudante
        /// </summary>
        /// <param name="id">Identificador do estudante</param>
        /// <returns>Nada.</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("students/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteStudent(int id)
        {
            var response = _studentService.Delete(id);
            if (response == null)
            {
                return NotFound(new { message = "Dados não encontrados" });
            }
            return NoContent();
        }
    }
}
