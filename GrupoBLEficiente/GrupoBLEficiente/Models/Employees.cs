using System.ComponentModel.DataAnnotations;

namespace GrupoBLEficiente.Models
{
    public class Employees
    {
        [Key]
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El número de identificación es requerido")]
        [Display(Name = "Número de Identificación")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "El número de teléfono es requerido")]
        [Display(Name = "Número Teléfonico")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        public string? Password { get; set; }

        [Display(Name = "Vacaciones Acumuladas")]
        public int? AccruedVacations { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "El puesto es requerido")]
        [Display(Name = "Puesto")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "El salario mensual bruto es requerido")]
        [Display(Name = "Salario Mensual Bruto")]
        public decimal MonthlySalary { get; set; }

        [Required(ErrorMessage = "El primer día de trabajo es requerido")]
        [Display(Name = "Primer Día de Trabajo")]
        public DateOnly FirstDay { get; set; }

        [Display(Name = "Horario")]
        public string? Schedule { get; set; }

        [Display(Name = "Rol")]
        public int? IdRol { get; set; }

        [Display(Name = "Estado")]
        public string? Status { get; set; }

        [Display(Name = "Comentarios")]
        public string? Description { get; set; }


        public Roles? Roles {get; set;}

        public List<Attendance>? Attendance { get; set; }

        public List<Paysheet> Paysheet { get; set; }   
    }
}
