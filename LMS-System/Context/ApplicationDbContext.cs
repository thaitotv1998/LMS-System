using Microsoft.EntityFrameworkCore;

namespace LMS_System.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base() { }
    }
}
