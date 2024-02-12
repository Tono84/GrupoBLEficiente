using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficienteAPI.Models
{
    public class Employees
    {
        public int IdEmployee { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int IdType { get; set; }

        public string NationalId { get; set; }

        public DateOnly BirthDate { get; set; }

        public DateOnly HireDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public decimal MonthlyGrossSalary { get; set; }

        public int IdJobTitle { get; set; }

        public string status { get; set; }

        [JsonIgnore]
        public NationalIdTypes? NationalIdTypes { get; set; }
        [JsonIgnore]
        public JobTitles? JobTitles { get; set; }
    }
    
}
