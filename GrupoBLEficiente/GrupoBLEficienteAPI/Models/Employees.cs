using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GrupoBLEficienteAPI.Models
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

        [DateFormatValidation(ErrorMessage = "El formato de la fecha de nacimiento debe ser dd/MM/yyyy.")]
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
        [Display(Name = "Dirección Físisca")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El salario es requerido")]
        [Display(Name = "Salario Bruto")]
        public decimal MonthlyGrossSalary { get; set; }

        [Required(ErrorMessage = "El titulo de trabajo es requerido")]
        [Display(Name = "Titulo de Trabajo")]
        public int IdJobTitle { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public string status { get; set; }

        [JsonIgnore]
        public NationalIdTypes? NationalIdTypes { get; set; }
        [JsonIgnore]
        public JobTitles? JobTitles { get; set; }
    }


    public class DateFormatValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                string dateString = date.ToString("MM/dd/yyyy"); // Convertir la fecha al formato MM/dd/yyyy

                // Intentar parsear la fecha en el formato MM/dd/yyyy
                if (DateTime.TryParseExact(dateString, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    // La fecha es válida
                    return ValidationResult.Success;
                }
                else
                {
                    // La fecha no es válida según el formato especificado
                    return new ValidationResult("El formato de la fecha no es válido. Debe estar en formato MM/dd/yyyy.");
                }
            }
            else if (value is DateOnly)
            {
                // Aquí también podrías agregar la lógica para validar fechas de tipo DateOnly, si es necesario
                return ValidationResult.Success;
            }
            else
            {
                // El valor no es del tipo esperado, devolver error de validación
                return new ValidationResult("El valor no es una fecha válida.");
            }
        }
    }


}
