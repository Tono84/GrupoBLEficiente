namespace GrupoBLEficiente.Models
{
    public class CCSSDeductions
    {   
        
        public int IdCCSSDeduction { get; set; }

        public string Name { get; set; }

        public Double Percentage { get; set; }

        public string Description { get; set; }

        public List<Paysheet>? PaySheets { get; set; }
    }
}
