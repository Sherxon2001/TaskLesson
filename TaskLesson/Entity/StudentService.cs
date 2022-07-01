using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskLesson.Contract;
using TaskLesson.DataLayer;
using TaskLesson.Dtos;
using TaskLesson.Models;
using TaskLesson.Template;

namespace TaskLesson.Entity
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _dbContext;

        public StudentService(AppDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public async Task<ResultModel<StudentDTO>> CreateStudentAsync(StudentDTO studentDTO)
        {
            ResultModel<StudentDTO> _state = new ResultModel<StudentDTO>();

            try
            {
                Guid Id = Guid.NewGuid();

                Student student = new Student();

                student.Id = Id;
                student.Fullname = studentDTO.Fullname;
                student.Email = studentDTO.Email;
                student.PhoneNumber = studentDTO.PhoneNumber;
                student.DatOfBirth = studentDTO.DatOfBirth;

                await _dbContext.Students.AddAsync(student);
                await _dbContext.SaveChangesAsync();

                _state.Code = 200;
                _state.Message = "success";
                _state.Data = studentDTO;
            }
            catch(Exception ex)
            {
                _state.Code = 500;
                _state.Message = ex.Message;
                _state.Data = null;
            }

            return _state;
        }

        public Task<ResultModel<StudentDTO>> DeleteStudentAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<List<StudentDTO>>> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<List<StudentDTO>>> GetStudentsByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<StudentDTO>> UpdateStudentAsync(StudentDTO student)
        {
            throw new NotImplementedException();
        }
    }
}
