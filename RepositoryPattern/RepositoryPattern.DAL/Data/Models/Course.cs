using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL;

public class Course
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
}
