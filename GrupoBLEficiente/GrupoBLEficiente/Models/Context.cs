using Microsoft.EntityFrameworkCore;
using GrupoBLEficiente.Models;

namespace GrupoBLEficiente.Models
{
    public class GBLContext : DbContext
    {
        public GBLContext(DbContextOptions<GBLContext> opciones) : base(opciones)
        {

        }
        public DbSet<Employees> Employees { get; set; }

        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(Employees =>
            {
                Employees.HasKey(x => x.IdEmployee);
                Employees.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);
                Employees.Property(X => X.LastName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);
            });
            modelBuilder.Entity<Roles>(Roles =>
            {
                Roles.HasKey(x => x.IdRol);
                Roles.Property(x => x.Description)
                .IsRequired().HasMaxLength(200);
                Roles.Property(x => x.Name)
                .IsRequired().HasMaxLength(200);
            });
            //modelBuilder.Entity<Employees>().HasOne(x => x.Roles).WithMany(x => x.Employees).HasForeignKey(f => f.IdRol);
        }
    }
}
