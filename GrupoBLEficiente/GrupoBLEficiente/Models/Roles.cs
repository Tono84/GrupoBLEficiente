using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GrupoBLEficiente.Models
{
    public class Roles
    {
        [Key]
        public int IdRol {  get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


     

    }
}
