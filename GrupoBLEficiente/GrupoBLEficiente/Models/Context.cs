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

        public DbSet<Attendance> Attendance { get; set; } 

        public DbSet<Paysheet> Paysheet { get; set; }

        public DbSet<TaxDeduction> TaxDeduction { get; set; }

        public DbSet<CCSSDeductions> CCSSDeductions { get; set; }

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
            modelBuilder.Entity<Attendance>(Attendance =>
            {
                Attendance.HasKey(x => x.IdAttendance);
                Attendance.Property(x => x.Description)
                .IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<CCSSDeductions>(CCSSDeductions =>
            {
                CCSSDeductions.HasKey(x => x.IdCCSSDeduction);
                CCSSDeductions.Property(x => x.Description)
                .IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<TaxDeduction>(TaxDeduction =>
            {
                TaxDeduction.HasKey(x => x.IdTaxDeduction);
                TaxDeduction.Property(x => x.Description)
                .IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<Paysheet>(Paysheet =>
            {
                Paysheet.HasKey(x => x.IdPaysheet);
                Paysheet.Property(x => x.Description)
                .IsRequired().HasMaxLength(200);
            });
            modelBuilder.Entity<Employees>().HasOne(x => x.Roles).WithMany(x => x.Employees).HasForeignKey(f => f.IdRol);
            modelBuilder.Entity<Attendance>().HasOne(x => x.Employees).WithMany(x => x.Attendance).HasForeignKey(f => f.IdEmployee);
            modelBuilder.Entity<Paysheet>().HasOne(x => x.Employees).WithMany(x => x.Paysheet).HasForeignKey(f => f.IdEmployee);
            modelBuilder.Entity<Paysheet>().HasOne(x => x.Attendance).WithMany(x => x.Paysheet).HasForeignKey(f => f.IdAttendance);
            modelBuilder.Entity<Paysheet>().HasOne(x => x.CCSSDeductions).WithMany(x => x.PaySheets).HasForeignKey(f => f.IdCCSSDeduction);
            modelBuilder.Entity<Paysheet>().HasOne(x => x.TaxDeduction).WithMany(x => x.Paysheets).HasForeignKey(f => f.IdTaxDeduction);
        }
    }
}
