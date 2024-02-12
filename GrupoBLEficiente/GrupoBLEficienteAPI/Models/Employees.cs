using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficienteAPI.Models
{
    public class Employees
    {
        [Key]
        public int IdEmployee { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento de Identificación")]
        public int IdType { get; set; }

        [Required]
        [Display(Name = "Número de Documento de Identificación")]
        public string NationalId { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly BirthDate { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio")]
        public DateOnly HireDate { get; set; }

        [Required]
        [Display(Name = "Correo Electr'onico")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Número Teléfonico")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Dirección Físisca")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Salario Bruto")]
        public decimal MonthlyGrossSalary { get; set; }

        [Required]
        [Display(Name = "Titulo de Trabajo")]
        public int IdJobTitle { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string status { get; set; }

        [JsonIgnore]
        public NationalIdTypes? NationalIdTypes { get; set; }
        [JsonIgnore]
        public JobTitles? JobTitles { get; set; }
    }
    
}
