using Library_Management_System.Models;

namespace Library_Management_System.Repository
{
    public interface IPatron
    {
        List<Patron> GetAllPatrons();
        Patron GetPatronById(int id);
        void AddPatron(Patron patron);
        void UpdatePatron( Patron updatedPatron);
        void DeletePatron(int id);
        void Save();

    }
}
