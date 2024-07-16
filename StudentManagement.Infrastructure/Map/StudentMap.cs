using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using StudentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Infrastructure.Map
{
    public class StudentMap : ClassMap<StudentModel>
    {
        public StudentMap()
        {
            {
                // Mapeamento das propriedades
                Map(m => m.Id).Index(0).TypeConverter<IntConverter>(); // Exemplo de uso do IntConverter
                Map(m => m.Nome).Index(1);
                Map(m => m.Idade).Index(2).TypeConverter<IntConverter>(); // Usando o IntConverter para Idade
                Map(m => m.Serie).Index(3).TypeConverter<IntConverter>(); // Usando o IntConverter para Série
                Map(m => m.NotaMedia).Index(4).TypeConverter<DoubleConverter>(); // Exemplo de uso de outro converter para double
                Map(m => m.Endereco).Index(5);
                Map(m => m.NomePai).Index(6);
                Map(m => m.NomeMae).Index(7);
                Map(m => m.DataNascimento).Index(8).TypeConverter<NullableDateTimeConverter>(); // Exemplo de uso de converter para DateTime
                Map(m => m.CreatedAt).Ignore();
                Map(m => m.UpdatedAt).Ignore();
            }
        }
    }
    public class IntConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return int.TryParse(text, out var result) ? result : 0;
        }
    }

    public class DoubleConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var result) ? result : 0.0;
        }
    }

    public class NullableDateTimeConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return DateTime.TryParse(text, out var result) ? result : (DateTime?)null;
        }
    }

}
