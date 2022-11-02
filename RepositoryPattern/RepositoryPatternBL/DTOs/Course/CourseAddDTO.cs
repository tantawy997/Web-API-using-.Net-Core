using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL.DTOs;

public class CourseAddDTO
{
    public Guid id { get; set; }
    public string name { get; set; } = "";


    public ICollection<StudentAddDTO> studentAddDTO = new HashSet<StudentAddDTO>();
}
