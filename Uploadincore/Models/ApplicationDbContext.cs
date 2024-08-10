using Microsoft.EntityFrameworkCore;
using Uploadincore.Models;

namespace Uploadincore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileUpload> FileUploads { get; set; }
    }
}

