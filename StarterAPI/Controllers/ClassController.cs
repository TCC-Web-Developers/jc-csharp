﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterAPI.Entities;
using StarterAPI.Interfaces;

namespace StarterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var classList = _classService.Get();
            return Ok(new { data = classList });
        }

        [HttpGet("details")]
        public async Task<IActionResult> Get(int classId)
        {
            var classItem = await _classService.Get(classId);
            return Ok(new { data = classItem });
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass(Class request, CancellationToken ct = default)
        {

            var newClass = await _classService.CreateClass(request, ct);
            return Ok(new { data = newClass });

        }

        [HttpPut]
        public async Task<IActionResult> UpdateClass(Class request, CancellationToken ct = default)
        {
            var newClass = await _classService.UpdateClass(request, ct);
            return Ok(new { data = newClass });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClass(int classId, CancellationToken ct = default)
        {
            var isDeleted = await _classService.DeleteClass(classId, ct);
            return Ok(new { data = isDeleted });
        }
    }
}
