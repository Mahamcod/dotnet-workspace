using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Upload.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ContactForm> ContactForms { get; set; }
    }

}