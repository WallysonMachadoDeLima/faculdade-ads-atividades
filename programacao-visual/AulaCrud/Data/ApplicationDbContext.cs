using Microsoft.EntityFrameworkCore;
using AulaCrud.Models;

namespace AulaCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aula> Aulas { get; set; }
    }
}
