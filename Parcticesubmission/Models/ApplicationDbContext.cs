using Parcticesubmission.Models;
using System.Data.Entity;

namespace Practicesubmission.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") // Use your connection string name here
        {
        }

        public DbSet<ContactViewModel> ContactModels { get; set; }
    }
}
