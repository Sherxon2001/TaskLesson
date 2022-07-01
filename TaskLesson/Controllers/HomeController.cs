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

        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var result = await _service.GetStudentsAsync();

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsByIdAsync(Guid Id)
        {
            var result = await _service.GetStudentsByIdAsync(Id);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudentAsync(Guid Id, StudentDTO student)
        {
            var result = await _service.UpdateStudentAsync(Id, student);

            return Ok(result.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentAsync(Guid Id)
        {
            var result = await _service.DeleteStudentAsync(Id);

            return Ok(result.Data);
        }
    }
}
