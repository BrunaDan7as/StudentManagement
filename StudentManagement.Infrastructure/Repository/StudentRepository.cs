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
        private string _csvFile;
        public StudentRepository(StudentContext context, IConfiguration appSettings
            ) : base(context)
        {
            _context = context;
            _csvFile = appSettings.GetConnectionString("CsvFilePath");
        }

        public void LoadCsvDataIntoDatabase()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";", // Define o delimitador como vírgula
                HasHeaderRecord = true, // Indica que não há cabeçalho no CSV
                Quote = '"', // Define o caractere de citação (aspas)
                TrimOptions = TrimOptions.Trim, // Trim para remover espaços em branco extras
            };

            using (var reader = new StreamReader(_csvFile))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<StudentMap>();
                var records = csv.GetRecords<StudentModel>().ToList();

                foreach (var record in records)
                {
                    Console.WriteLine($"Id: {record.Id}, Nome: {record.Nome}, Idade: {record.Idade}, Serie: {record.Serie}, Nota Média: {record.NotaMedia}, Endereço: {record.Endereco}, Nome do Pai: {record.NomePai}, Nome da Mãe: {record.NomeMae}, Data de Nascimento: {record.DataNascimento}, Criado em: {record.CreatedAt}, Atualizado em: {record.UpdatedAt}");
                }

                // Aqui você pode inserir os registros no banco de dados usando Entity Framework Core ou outra tecnologia
            }

            //using (var csv = new CsvReader(reader, config))
            //{
            //    var records = new List<StudentModel>();

            //    while (csv.Read())
            //    {
            //        var teste = csv.GetField<int>(0);
            //        var record = new StudentModel
            //        {
            //            Id = csv.GetField<int>(0),
            //            Nome = csv.GetField<string>(1),
            //            Idade = csv.GetField<int>(2),
            //            Serie = csv.GetField<int>(3),
            //            NotaMedia = csv.GetField<double>(4),
            //            Endereco = csv.GetField<string>(5),
            //            NomePai = csv.GetField<string>(6),
            //            NomeMae = csv.GetField<string>(7),
            //            // DataNascimento = csv.GetField<DateTime>(8), // Exemplo de como lidar com datas se necessário
            //        };

            //        records.Add(record);
            //    }

            //// Reiniciar o leitor de stream e o CsvReader para a leitura real
            //reader.BaseStream.Seek(0, SeekOrigin.Begin);
            //reader.DiscardBufferedData();

            //csv.Context.RegisterClassMap<StudentMap>(); // Registrando o ClassMap personalizado
            //var students = csv.GetRecords<object>().ToList();



            //_context.Students.AddRange(students);
            _context.SaveChanges();
            
        }
    }
}
