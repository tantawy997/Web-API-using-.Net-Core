using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL;

public interface IStudentRepo : IGenricRepo<Student>
{
    List<Student> GetByPhone(string Phone);
}
