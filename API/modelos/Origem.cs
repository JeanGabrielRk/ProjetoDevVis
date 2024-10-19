using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Origem 
    {
        [Key]
        public int IdOrigem { get; set; }
        public string Pais { get; set; } // Removido o '?', já que deve ser obrigatório
        public ICollection<Planta> Plantas { get; set; } = new List<Planta>();
    }
}
