using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BorrowingRecord
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Book is required")]
        public Book Book { get; set; }

        [Required(ErrorMessage = "Patron is required")]
        public Patron Patron { get; set; }

        [Required(ErrorMessage = "Borrow date is required")]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [Required(ErrorMessage = "Return date is required")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public bool IsValidBorrowingRecord()
        {
            return ReturnDate >= BorrowDate;
        }
    }
}
