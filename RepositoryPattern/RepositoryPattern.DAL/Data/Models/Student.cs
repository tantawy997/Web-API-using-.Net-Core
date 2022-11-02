using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL;

public class Student
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Grade { get; set; } = "";


    public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
}
