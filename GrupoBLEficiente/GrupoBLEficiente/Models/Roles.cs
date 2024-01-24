using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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


     

    }
}
