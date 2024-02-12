using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficienteAPI.Models
{
    public class NationalIdTypes
    {
        [Key]
        public int Idtype { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento de Identificación")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [JsonIgnore]
        public List<Employees>? Employees { get; set; }
    }
}
