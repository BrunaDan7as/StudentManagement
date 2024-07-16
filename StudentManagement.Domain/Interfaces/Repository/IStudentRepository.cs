using StudentManagement.Domain.Interfaces.Repository.Base;
using StudentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Interfaces.Repository
{
    public interface IStudentRepository : IRepositoryBase<StudentModel,long>
    {
        //void LoadCsvDataIntoDatabase();
    }
}
