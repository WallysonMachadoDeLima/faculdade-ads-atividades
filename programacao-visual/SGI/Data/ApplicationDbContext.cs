using Microsoft.EntityFrameworkCore;
using SGI.Models;

namespace SGI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produtos");

                entity.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Preco)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                entity.Property(p => p.Quantidade)
                    .IsRequired()
                    .HasDefaultValue(0);
            });
        }
    }
}
