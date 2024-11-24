using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserCapture.Models
{
    public class UserData : ValidationAttribute
    {
        public string Id { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        //
        [StringLength(10, MinimumLength = 10)]
        [DisplayName("Cellphone number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Not a valid phone number")]
        public string Cellnumber { get; set; }
    }
}
