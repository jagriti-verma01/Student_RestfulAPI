using FluentValidation;
using interviewpractice.Models;
using interviewpractice.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetStudentList()
        {
            var studentList = await _studentService.StudentList();
            return studentList;
        }
        [Authorize(Roles = "Admin")]
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

        [HttpGet("course/{course}")]
        public  Task<StudentModel> GetStudentByCourse( string course)
        {
            var student = _studentService.FindStudentByCourse(course);
            return student;
        }

        [Authorize(Roles = "User")]
        [HttpPost]

        public async Task<ActionResult<StudentModel>> AddStudent([FromBody] StudentModel student)
        {
            try
            {
                var addstudent = await _studentService.AddStudentService(student);

                return Ok(addstudent);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    Errors = ex.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Message = e.ErrorMessage
                    })
                });
            }
        }
    }
}
