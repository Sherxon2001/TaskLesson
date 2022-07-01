using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLesson.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        public string Fullname { get; set; }

        public DateTime DatOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
