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
        private readonly IApplicationDbContext _context;

        public StudentController(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(new object[] {id});

            if (student == null)
            {
                return BadRequest(new { error = "Student not found." });
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult DeleteStudent()
        {
            throw new NotImplementedException();
        }
    }
}
