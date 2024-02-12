using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;
using GrupoBLEficienteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficienteAPI.Models
{
    public class JobTitles
    {
        [Key]
        public int IdJobTitle { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public List<Employees>? Employees { get; set; }

    }
}