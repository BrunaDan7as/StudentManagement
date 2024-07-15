using StudentManagement.Domain.Models.Base;

namespace StudentManagement.Domain.Models
{
    public class StudentModel : BaseModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Serie { get; set; }
        public double NotaMedia { get; set; }
        public string Endereco { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
