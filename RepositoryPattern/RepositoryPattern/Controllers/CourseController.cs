using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DAL;
using RepositoryPatternBL.DTOs;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext context;

        public CourseController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(context.Courses.Include(p => p.Students).ToList());
        }

        ////[HttpPost]
        ////public ActionResult AddingCoursesToStudent(List<Guid> CourseIds, Guid studentId)
        ////{
        ////    //var courses = context.Students.Include(a => a.Courses).Where(i => i.CourseId == CourseId)
        ////    var course = context.Students.Where(a => CourseIds.Contains(a.CourseId)).ToList();
        ////    var student = context.Courses.Include(a => a.Students).First(a => a.Id == studentId);

        ////    //context.SaveChanges();
        ////    return NoContent();
        ////}

    }
}
