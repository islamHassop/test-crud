//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace testCREST.Models
{
    public class DataContext:IdentityDbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions options):base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<Facluty> faclutys { get; set; }
       

    }
}
