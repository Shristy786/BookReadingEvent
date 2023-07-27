using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Data
{
    public class BookEventContext : IdentityDbContext<ApplicationUser>
    {
        public BookEventContext(DbContextOptions<BookEventContext>options)
            : base(options)
        {

        }
            public DbSet<CreateEvent> CreateEvent { get; set; }
        
    }
}
