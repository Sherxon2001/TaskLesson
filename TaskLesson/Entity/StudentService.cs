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

        public async Task<ResultModel<StudentDTO>> DeleteStudentAsync(Guid Id)
        {
            ResultModel<StudentDTO> _state = new ResultModel<StudentDTO>();

            try
            {
                StudentDTO studentDTO = new StudentDTO();
                var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == Id);

                if(student is not null)
                {
                    studentDTO.Fullname = student.Fullname;
                    studentDTO.DatOfBirth = student.DatOfBirth;
                    studentDTO.Email = student.Email;
                    studentDTO.PhoneNumber = student.PhoneNumber;

                    _state.Code = 200;
                    _state.Message = nameof(TemplateEnum.success);
                    _state.Data = studentDTO;

                    _dbContext.Students.Remove(student);
                    await _dbContext.SaveChangesAsync();
                }
                else if(student is null)
                {
                    _state.Code = 404;
                    _state.Message = nameof(TemplateEnum.notFound);
                    _state.Data = null;
                }
               
            }
            catch (Exception ex)
            {
                _state.Code = 500;
                _state.Message = ex.Message;
                _state.Data = null;
            }

            return _state;
        }

        public async Task<ResultModel<List<Student>>> GetStudentsAsync()
        {
            ResultModel<List<Student>> _state = new ResultModel<List<Student>>();

            try
            {
                var result = await _dbContext.Students.ToListAsync();

                _state.Code = 200;
                _state.Message = "success";
                _state.Data = result;
            }
            catch (Exception ex)
            {
                _state.Code = 500;
                _state.Message = ex.Message;
                _state.Data = null;
            }

            return _state;
        }

        public async Task<ResultModel<StudentDTO>> GetStudentsByIdAsync(Guid Id)
        {
            ResultModel<StudentDTO> _state = new ResultModel<StudentDTO>();

            try
            {
                StudentDTO studentDTO = new StudentDTO();
                var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == Id);

                if (student is not null)
                {
                    studentDTO.Fullname = student.Fullname;
                    studentDTO.DatOfBirth = student.DatOfBirth;
                    studentDTO.Email = student.Email;
                    studentDTO.PhoneNumber = student.PhoneNumber;


                    _state.Code = 200;
                    _state.Message = "success";
                    _state.Data = studentDTO;
                }
                else if (student is null)
                {
                    _state.Code = 404;
                    _state.Message = "success";
                    _state.Data = null;
                }

            }
            catch (Exception ex)
            {
                _state.Code = 500;
                _state.Message = ex.Message;
                _state.Data = null;
            }

            return _state;
        }

        public async Task<ResultModel<StudentDTO>> UpdateStudentAsync(Guid Id, StudentDTO student)
        {
            ResultModel<StudentDTO> _state = new ResultModel<StudentDTO>();

            try
            {
                StudentDTO studentDTO = new StudentDTO();
                var result = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == Id);

                if (student is not null)
                {
                    result.Fullname = student.Fullname;
                    result.DatOfBirth = student.DatOfBirth;
                    result.Email = student.Email;
                    result.PhoneNumber = student.PhoneNumber;

                    studentDTO.Fullname = student.Fullname;
                    studentDTO.DatOfBirth = student.DatOfBirth;
                    studentDTO.Email = student.Email;
                    studentDTO.PhoneNumber = student.PhoneNumber;

                    _state.Code = 200;
                    _state.Message = "success";
                    _state.Data = studentDTO;

                    await _dbContext.SaveChangesAsync();
                }
                else if (student is null)
                {
                    _state.Code = 404;
                    _state.Message = "success";
                    _state.Data = null;
                }

            }
            catch (Exception ex)
            {
                _state.Code = 500;
                _state.Message = ex.Message;
                _state.Data = null;
            }

            return _state;
        }
    }
}
