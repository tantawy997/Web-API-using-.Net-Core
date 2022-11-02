using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL;

public class StudentRepo : GenricRepo<Student>, IStudentRepo
{
    private readonly AppDbContext context;
      
    public StudentRepo(AppDbContext _context) : base(_context)
    {
        context = _context;
    }

    public List<Student> GetByPhone(string Phone)
    {
        return context.Set<Student>()
            .Where(stud => stud.Phone == Phone)
            .ToList();
    }
}
