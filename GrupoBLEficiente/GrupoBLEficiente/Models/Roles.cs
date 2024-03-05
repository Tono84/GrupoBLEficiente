using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficiente.Models
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="El nombre del Rol es Requerido")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [JsonIgnore]
        public List<Users>? Users { get; set; }

    }
}
