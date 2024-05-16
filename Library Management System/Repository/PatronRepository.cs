using Library_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Library_Management_System.Repository
{
    public class PatronRepository :IPatron
    {
        Context context;


        public PatronRepository(Context _context)
        {

            context = _context;
        }

        public List<Patron> GetAllPatrons()
        {
            return context.Patrons.ToList();
        }

        public Patron GetPatronById(int id)
        {
            return context.Patrons.FirstOrDefault(b => b.ID == id);
        }

        public void AddPatron(Patron obj)
        {
            context.Patrons.Add(obj);
            context.SaveChanges();
        }

        public void UpdatePatron(Patron updatedPatron)
        {
            if (updatedPatron != null)
            {
                context.Update(updatedPatron);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(updatedPatron), "Updated patron cannot be null");
            }
        }

        public void DeletePatron(int id)
        {
            Patron existingPatron = context.Patrons.FirstOrDefault(b => b.ID == id);
            if (existingPatron != null)
            {
                context.Remove(existingPatron);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("patron not found.");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
