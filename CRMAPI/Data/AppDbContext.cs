using CRMAPI.Data;
using CRMAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> user { get; set; }

    }
}
