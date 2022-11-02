using RepositoryPattern.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL.DTOs;

public class StudentUpdateDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Phone { get; set; } = "";

    public ICollection<CourseUpdateDTO> courseUpdateDTO  = new HashSet<CourseUpdateDTO>();

}
