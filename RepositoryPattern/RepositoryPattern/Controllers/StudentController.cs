using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternBL;
using RepositoryPatternBL.DTOs;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager studentManager;

        public StudentController(IStudentManager _studentManager )
        {
            studentManager = _studentManager;
        }

        [HttpGet]   
        public ActionResult<IEnumerable<StudentReadDTO>> GetAllStudents()
        {
            return studentManager.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<StudentReadDTO> GetStudent(Guid id)
        {
            var student = studentManager.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;

        }

        [HttpPut("{id}")]

        public ActionResult<StudentManager> EditStudent(Guid id, StudentUpdateDTO studentUpdate)
        {
            if (id != studentUpdate.Id)
            {
                return BadRequest(new {message= "invalid id"});
            }
            //var student = studentManager.GetById(id);
            var result = studentManager.update(studentUpdate);
            
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<StudentAddDTO> AddStudent(StudentAddDTO studentAdd)
        {
            var studentToAdd = studentManager.Add(studentAdd);
            return CreatedAtAction("GetStudent", new {id = studentToAdd.Id}, studentToAdd);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(Guid id)
        {
            studentManager.Delete(id);
            return NoContent();  
        }

        [HttpGet]
        [Route("phone")]
        
        public ActionResult<IEnumerable< StudentReadDTO>> GetStudentbyPhone(string StudentPhone)
        {

            return studentManager.GetbyPhone(StudentPhone);
             
        }

    }
}
