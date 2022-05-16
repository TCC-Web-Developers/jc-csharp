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
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _service.GetStudents();   
            return Ok(students);
        }

        //GET ONE
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            var student = await _service.GetStudent(studentId);

            if (student == null)
            {
                return BadRequest(new { error = "Student not found." });
            }

            return Ok(student);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student param, CancellationToken ct = default)
        {
            try
            {
                return Ok(await _service.CreateStudent(param, ct));
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = "Student not found." , exception });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student param, CancellationToken ct = default)
        {
 
            try
            {
                await _service.UpdateStudent(param, ct);

                return Ok(_service.GetStudents());

            }
            catch (Exception exception)
            {
                return BadRequest(new { error = "Student not found." , exception });
            }

        }

        [HttpDelete("delete/{studentId}")]
        public async Task<IActionResult> DeleteStudent(int studentId, CancellationToken ct = default)
        {
            try
            {
                await _service.DeleteStudent(studentId, ct); 
                return Ok(_service.GetStudents());

            }
            catch (Exception exception)
            {
                return BadRequest(new { error = "Student not found." , exception });
            }

        }

    }
}
