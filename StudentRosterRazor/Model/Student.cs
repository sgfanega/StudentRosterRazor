using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRosterRazor.Model
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Grade { get; set; }
        public string Gender { get; set; }
    }
}
