using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StarterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            throw new NotImplementedException();
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
