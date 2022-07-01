using System.Threading.Tasks;
using TaskLesson.Template;
using TaskLesson.Dtos;
using System;
using System.Collections.Generic;
using TaskLesson.Models;

namespace TaskLesson.Contract
{
    public interface IStudentService
    {
        Task<ResultModel<StudentDTO>> CreateStudentAsync(StudentDTO student);
        Task<ResultModel<StudentDTO>> DeleteStudentAsync(Guid Id);
        Task<ResultModel<List<Student>>> GetStudentsAsync();
        Task<ResultModel<StudentDTO>> GetStudentsByIdAsync(Guid Id);
        Task<ResultModel<StudentDTO>> UpdateStudentAsync(Guid Id, StudentDTO student);
    }
}
