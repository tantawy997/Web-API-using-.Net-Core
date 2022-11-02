using RepositoryPattern.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL.DTOs;

public class StudentReadDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Grade { get; set; } = "";

    public ICollection<CourseReadDTO> Courses { get; set; } = new HashSet<CourseReadDTO>();

}
