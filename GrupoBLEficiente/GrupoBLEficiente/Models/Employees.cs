using System.ComponentModel.DataAnnotations;

namespace GrupoBLEficiente.Models
{
    public class Employees
    {
        [Key]
        public int IdEmployee { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string NationalId { get; set; }

        [Required]
        public string Phone {  get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public int AccruedVacations { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public decimal MonthlySalary { get; set; }

        [Required]
        public DateOnly FirstDay { get; set; }

        public string Schedule { get; set; }

        public int IdRol {  get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

    }
}
