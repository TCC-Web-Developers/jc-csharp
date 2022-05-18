using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterAPI.Entities;
using StarterAPI.Interfaces;

namespace StarterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;  
        }

        //GET ALL
        [HttpGet()]
        public IActionResult GetStudents()
        {
            var students = _service.GetStudents();   
            return Ok(students);
        }

        //GET ONE
        [HttpGet("profile/{studentId}")]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            var student = await _service.GetStudent(studentId);

            return Ok(new { data = student });
        }

        //POST
        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent(Student param, CancellationToken ct = default)
        {
            var newStudent = await _service.CreateStudent(param, ct);   
            return Ok(new { data = newStudent });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent(Student param, CancellationToken ct = default)
        {
 
           var updatedStudent = await _service.UpdateStudent(param, ct);  
           return Ok(new { data = updatedStudent});

        }

        [HttpDelete("delete/{studentId}")]
        public async Task<IActionResult> DeleteStudent(int studentId, CancellationToken ct = default)
        {
           var isDeleted = await _service.DeleteStudent(studentId, ct);
            return Ok(new { data = isDeleted });
        }

    }
}
