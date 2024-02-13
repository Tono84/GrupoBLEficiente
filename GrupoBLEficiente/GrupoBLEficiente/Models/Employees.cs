
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficiente.Models
{
    public class Employees
    {
        [Key]
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El de tipo de documento es requerido")]
        [Display(Name = "Tipo de Documento de Identificación")]
        public int IdType { get; set; }

        [Required(ErrorMessage = "El número de documento es requerido")]
        [Display(Name = "Número de Documento de Identificación")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [Display(Name = "Fecha de Inicio")]
        public DateOnly HireDate { get; set; }

        [Required(ErrorMessage = "El correo electrónico requerido")]
        [EmailAddress(ErrorMessage ="Utilice el formato de correo electrónico")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El número teléfonico es requerido")]
        [Display(Name = "Número Teléfonico")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [Display(Name = "Dirección Física")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El salario es requerido")]
        [Display(Name = "Salario Bruto")]
        public decimal MonthlyGrossSalary { get; set; }

        [Required(ErrorMessage = "El titulo de trabajo es requerido")]
        [Display(Name = "Titulo de Trabajo")]
        public int IdJobTitle { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public string Status { get; set; }

        [JsonIgnore]
        public NationalIdTypes? NationalIdTypes { get; set; }
        [JsonIgnore]
        public JobTitles? JobTitles { get; set; }
    }
    
}
