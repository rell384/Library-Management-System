using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library_Management_System.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<BorrowingRecord>borrowingRecords { get; set; }
        public Context(DbContextOptions options) : base(options)
        {

        }
    }
}
