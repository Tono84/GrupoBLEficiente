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
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public List<Employees>? Employees { get; set; }
    }
}
