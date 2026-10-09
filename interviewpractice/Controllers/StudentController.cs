using interviewpractice.Models;
using interviewpractice.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace interviewpractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService; 
        }
      

        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetStudentList()
        {
            var studentList = await _studentService.StudentList();
            return studentList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            
            var studentId = await _studentService.FindStudent(id);
            if (studentId == null)
            {
                return NotFound("id not found");
            }               
            return Ok(studentId);
        }

        [HttpPost]

        public async Task<ActionResult<StudentModel>> AddStudent([FromBody]StudentModel student)
        {
            var addstudent = await _studentService.AddStudentService(student);

            return Ok(addstudent);
        }
    }
}
