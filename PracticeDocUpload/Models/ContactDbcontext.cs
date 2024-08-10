using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticeDocUpload.Models
{
    public class ContactDbcontext :DbContext

    {

        public ContactDbcontext() : base("DefaultConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}