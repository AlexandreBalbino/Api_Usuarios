using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infradata
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
