using Library_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library_Management_System.Repository
{
    public class BorrowRepository : IBorrow
    {
        private readonly Context _context;

        public BorrowRepository(Context context)
        {
            _context = context;
        }

        public async Task BorrowBook(int bookId, int patronId)
        {
            // Retrieve the book and patron from the database
            var book = await _context.Books.FindAsync(bookId);
            var patron = await _context.Patrons.FindAsync(patronId);

            if (book == null || patron == null)
            {
                throw new InvalidOperationException("Book or Patron are  not found.");

            }

            // Create a new borrowing record
            var borrowingRecord = new BorrowingRecord
            {
                Book = book,
                Patron = patron,
                BorrowDate = DateTime.Today,
                ReturnDate = DateTime.Today.AddDays(14) //
            };

            _context.borrowingRecords.Add(borrowingRecord);
            await _context.SaveChangesAsync();
        }
    }
}
