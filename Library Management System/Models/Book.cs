using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Range(1000, 9999, ErrorMessage = "Publication year must be between 1000 and 9999")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "ISBN must be a 6-digit number")]
        public string ISBN { get; set; }
    }
}
