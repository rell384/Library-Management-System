using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Patron
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be a 10-digit number")]
        public string PhoneNumber { get; set; }
    }
}
