using System.ComponentModel.DataAnnotations;
using GrupoBLEficiente.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace GrupoBLEficiente.Models
{
    public class JobTitles
    {
        [Key]
        public int IdJobTitle { get; set; }

        [Required(ErrorMessage ="El titulo de trabajo es requerido")]
        [Display(Name = "Titulo de Trabajo")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [JsonIgnore]
        public List<Employees>? Employees { get; set; }

    }
}