using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficiente.Models
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int IdRol { get; set; }

        public int IdEmployee { get; set; }

        [JsonIgnore]
        public Roles? Roles { get; set; }

        [JsonIgnore]
        public Employees? Employees { get; set; }
    }
}
