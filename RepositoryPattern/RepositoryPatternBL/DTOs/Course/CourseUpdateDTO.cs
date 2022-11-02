using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL.DTOs;

public class CourseUpdateDTO
{
    public Guid id { get; set; }

    public string name { get; set; } = "";

    public ICollection<StudentUpdateDTO> studentUpdateDTO = new HashSet<StudentUpdateDTO>();
}
