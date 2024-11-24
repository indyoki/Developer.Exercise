using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Models
{
    public class Student
    {
        [Key]
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Campus { get; set; }
        public string FieldOfStudy { get; set; }
    }
}
