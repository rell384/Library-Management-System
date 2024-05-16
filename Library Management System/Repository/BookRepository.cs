using Library_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Library_Management_System.Repository
{
    public class BookRepository :IBook
    {
        Context context;


        public BookRepository(Context _context)
        {

            context = _context;
        }

        public List<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return context.Books.FirstOrDefault(b => b.ID == id);
        }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void UpdateBook( Book updatedBook)
        {
           if (updatedBook != null)
            {
                context.Update(updatedBook);
                context.SaveChanges();
            }
           else
            {
                throw new ArgumentNullException(nameof(updatedBook), "Updated book cannot be null");
            }
        }
     
        public void DeleteBook(int id)
        {
            Book existingBook = context.Books.FirstOrDefault(b => b.ID == id);
            if (existingBook != null)
            {
                context.Remove(existingBook);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Book not found.");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
