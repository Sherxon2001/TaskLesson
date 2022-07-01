using System.Threading.Tasks;
using TaskLesson.Template;
using TaskLesson.Dtos;
using System;
using System.Collections.Generic;

namespace TaskLesson.Contract
{
    public interface IStudentService
    {
        Task<ResultModel<StudentDTO>> CreateStudentAsync(StudentDTO student);
        Task<ResultModel<StudentDTO>> DeleteStudentAsync(Guid Id);
        Task<ResultModel<List<StudentDTO>>> GetStudentsAsync();
        Task<ResultModel<List<StudentDTO>>> GetStudentsByIdAsync();
        Task<ResultModel<StudentDTO>> UpdateStudentAsync(StudentDTO student);
    }
}
