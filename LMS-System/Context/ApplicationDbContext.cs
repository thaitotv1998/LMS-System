using LMS_System.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
    }
}
