using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public interface IBorrow
    {
       public Task BorrowBook(int bookId, int patronId);

    }
}
