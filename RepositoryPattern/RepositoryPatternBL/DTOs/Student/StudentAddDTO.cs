using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL.DTOs;

public class StudentAddDTO
{

    public string Name { get; set; } = "";

    public string Phone { get; set; } = "";


    public ICollection<CourseAddDTO> Courses { get; set; } = new HashSet<CourseAddDTO>();
}
