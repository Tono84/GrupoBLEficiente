using System.ComponentModel.DataAnnotations;

namespace GrupoBLEficiente.Models
{
    public class TaxDeduction
    {
        [Key]
        public int IdTaxDeduction { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Porcentage de la Deducción es requerido")]
        [Display(Name = "Porcentaje de Deducción")]
        public Double Percentage { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public List<Paysheet>? Paysheets { get; set; }
    }
}
