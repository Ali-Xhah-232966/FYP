using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using FYP.DAL.Entities;

namespace FYP.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ContactUs> ContactUsMessages { get; set; }
        public DbSet<ProjectSubmission> ProjectSubmissions { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AppUser> GoogleUsers { get; set; }







    }
}
