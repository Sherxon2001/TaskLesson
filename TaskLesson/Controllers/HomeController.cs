using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskLesson.Contract;
using TaskLesson.Dtos;

namespace TaskLesson.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IStudentService _service;

        public HomeController(IStudentService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(StudentDTO student)
        {
            var result = await _service.CreateStudentAsync(student);

            return Ok(result.Data);
        }
    }
}
