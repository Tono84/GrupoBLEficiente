using System.ComponentModel.DataAnnotations;

namespace GrupoBLEficiente.Models
{
    public class Attendance
    {
        [Key]
        public int IdAttendance { get; set; }

        [Required(ErrorMessage ="La asistencia se debe asignar a un empleado")]
        [Display(Name ="Empleado")]
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "Los días trabajados son requeridos")]
        [Display(Name = "Días Trabajados")]
        public int WorkDays { get; set; }

        [Display(Name = "Ausencias")]
        public int Absences { get; set; }

        [Display(Name = "Vacaciones Disfrutadas")]
        public int Vacations { get; set; }

        [Required(ErrorMessage = "La fecha de inicio de Periodo es Requerida")]
        [Display(Name = "Inicio de Periodo")]
        public DateOnly PayPeriodStart {  get; set; }

        [Required(ErrorMessage = "La fecha de fin de Periodo es Requerida")]
        [Display(Name = "Fin de Periodo")]
        public DateOnly PayPeriodEnd { get; set; }

        [Display(Name = "Comisiones")]
        public Double? commissions { get; set; }

        [Display(Name = "Guardias")]
        public Double? OnCallHours {  get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        public Employees? Employees { get; set; }

        public List<Paysheet>? Paysheet { get; set; } 
    }
}
