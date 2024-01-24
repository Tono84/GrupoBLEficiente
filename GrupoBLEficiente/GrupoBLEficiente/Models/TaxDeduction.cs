namespace GrupoBLEficiente.Models
{
    public class TaxDeduction
    {
        public int IdTaxDeduction { get; set; }

        public string Name { get; set; }

        public Double Percentage { get; set; }

        public string Description { get; set; }

        public List<Paysheet>? Paysheets { get; set; }
    }
}
