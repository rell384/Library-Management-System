using Library_Management_System.Models;
namespace Library_Management_System.Repository
{
    public interface IBook
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook( Book updatedBook);
        void DeleteBook(int id);
        void Save();
       
    }
}
