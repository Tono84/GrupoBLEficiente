using Microsoft.EntityFrameworkCore;
using GrupoBLEficienteAPI.Models;

namespace GrupoBLEficienteAPI.Models
{
    public class GBLContext : DbContext
    {
        public GBLContext(DbContextOptions<GBLContext> opciones) : base(opciones)
        {

        }
        public DbSet<Employees> Employees { get; set; }

        public DbSet<NationalIdTypes> NationalIdTypes { get; set; }

        public DbSet<JobTitles> JobTitles { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Users> Users { get; set; }

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

            modelBuilder.Entity<JobTitles>(JobTitles =>
            {
                JobTitles.HasKey(x => x.IdJobTitle);
                JobTitles.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);
                JobTitles.Property(X => X.Name)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);
            });

            modelBuilder.Entity<NationalIdTypes>(NationalIdTypes =>
            {
                NationalIdTypes.HasKey(x => x.IdType);
                NationalIdTypes.Property(x => x.Name)
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

            modelBuilder.Entity<Users>(Users =>
            {
                Users.HasKey(x => x.IdUser);
                Users.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Employees>().HasOne(x => x.NationalIdTypes).WithMany(x => x.Employees).HasForeignKey(f => f.IdType);
            modelBuilder.Entity<Employees>().HasOne(x => x.JobTitles).WithMany(x => x.Employees).HasForeignKey(f => f.IdJobTitle);
            modelBuilder.Entity<Users>().HasOne(x => x.Employees).WithOne(x => x.Users).HasForeignKey<Users>(f => f.IdEmployee);
            modelBuilder.Entity<Users>().HasOne(x => x.Roles).WithMany(x => x.Users).HasForeignKey(f => f.IdRol);

        }
    }
}
