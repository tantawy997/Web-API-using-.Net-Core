using RepositoryPattern.DAL;
using RepositoryPatternBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL;

public class CourseReadDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";


    public ICollection<StudentReadDTO> students { get; set; } = new HashSet<StudentReadDTO>();

}
