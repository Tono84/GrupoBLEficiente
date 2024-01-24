using System.ComponentModel.DataAnnotations;

namespace GrupoBLEficiente.Models
{
    public class Paysheet
    {
        [Key]
        public int IdPaysheet { get; set; }

        [Display(Name="Empleado")]
        [Required(ErrorMessage="El empleado debe de ser elegido")]
        public int IdEmployee { get; set; }

        [Display(Name = "Registro de Asistencia")]
        [Required(ErrorMessage = "Se debe de Elegir un registro")]
        public int IdAttendance { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string EmployeeFullName { get; set; }

        [Display(Name = "Número de Identificación")]
        [Required(ErrorMessage = "El número de Identificación es requerido")]
        public string EmployeeNationalId { get; set; }

        [Display(Name = "Periodo de Pago")]
        [Required(ErrorMessage = "El Periodo de Pago es requerido")]
        public DateOnly PayPeriod { get; set; }

        [Display(Name = "Salario Bruto Mensual")]
        [Required(ErrorMessage = "El Salario Bruto es requerido")]
        public Double GrossSalary { get; set; }

        [Display(Name = "Salario Quincenal Mensual")]
        [Required(ErrorMessage = "El Salario Quincenal Bruto es requerido")]
        public Double BiweeklyGrossSalary { get; set; }

        [Display(Name = "Comisiones")]
        public Double Commissions { get; set; }

        [Display(Name = "Guardias")]
        public Double OnCall { get; set; }

        [Display(Name = "Vacaciones Disfrutadas")]
        public Double Vacations { get; set; }

        [Display(Name = "Total antes de Rebajos")]
        [Required(ErrorMessage = "El Total es requerido")]
        public Double TotalPay { get; set; }


        [Display(Name = "Otros Pagos")]
        public Double OtherSalary { get; set; }


        [Display(Name = "Ausencias")]
        public Double AbsencesDeductions { get; set; }


        [Display(Name = "C.C.S.S")]
        [Required(ErrorMessage = "La Deducción por C.C.S.S es requerida")]
        public int IdCCSSDeduction {  get; set; }

        [Display(Name = "Impuestos sobre la renta")]
        [Required(ErrorMessage = "La Deducción por impuestos es requerida")]
        public int IdTaxDeduction { get; set; }

        [Display(Name = "Otras deducciones")]
        public Double OtherDeductions { get; set; }

        [Display(Name = "Pago Total")]
        [Required(ErrorMessage = "El Pago total es requerido")]
        public Double NetPay {  get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public Employees? Employees { get; set; }

        public Attendance? Attendance { get; set; }

        public CCSSDeductions? CCSSDeductions { get; set; }

        public TaxDeduction? TaxDeduction { get; set;}
    }
}
