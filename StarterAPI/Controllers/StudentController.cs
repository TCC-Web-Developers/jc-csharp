﻿using Microsoft.AspNetCore.Http;
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

        //GET ALL
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.Students.ToList());
        }

        //GET ONE
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(new object[] { studentId });

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
                var newStudent = new Student
                {
                    FirstName = param.FirstName,
                    LastName = param.LastName,
                    EmailAddress = param.EmailAddress,
                    Birthdate = param.Birthdate,
                    DateEnrolled = param.DateEnrolled,
                };

                _context.Students.Add(newStudent);

                await _context.SaveChangesAsync(ct);

                string generatedStudentNo
                    = Convert.ToDateTime(param.DateEnrolled).ToString("yyyMMdd") + "-" + newStudent.StudentId;

                newStudent.StudentNo = generatedStudentNo;

                await _context.SaveChangesAsync(ct);

                return Ok(newStudent);

            }
            catch (Exception exception)
            {
                return BadRequest(new { error = "Student not found.", exception = exception });
            }

            throw new NotImplementedException();

        }
    }
}
