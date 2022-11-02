using RepositoryPatternBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL;

public interface IStudentManager
{
    List<StudentReadDTO> GetAll();

    StudentReadDTO? GetById(Guid id);

    StudentReadDTO Add(StudentAddDTO Student);

    bool update(StudentUpdateDTO Student);

    void Delete(Guid id);

    List<StudentReadDTO> GetbyPhone(string phone);
}
