﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrupoBLEficienteAPI.Models
{
    public class NationalIdTypes
    {
        [Key]
        public int IdType { get; set; }

        [Required(ErrorMessage ="El tipo de documento de identificación es requerido")]
        [Display(Name = "Tipo de Documento de Identificación")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [JsonIgnore]
        public List<Employees>? Employees { get; set; }
    }
}
