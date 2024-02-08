using System.ComponentModel.DataAnnotations;

namespace GrupoBLEficiente.Models
{
    public class CCSSDeductions
    {
        [Key]
        public int IdCCSSDeduction { get; set; }

        [Required(ErrorMessage="El Nombre es requerido")]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Porcentage de la Deducción es requerido")]
        [Display(Name = "Porcentaje de Deducción")]
        public Double Percentage { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public List<Paysheet>? PaySheets { get; set; }
    }
}
