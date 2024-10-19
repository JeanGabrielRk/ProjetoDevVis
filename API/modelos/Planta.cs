using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Planta
    {
        [Key]
        public int IdPlanta { get; set; }
        public string Nome { get; set; } // Removido o '?', já que deve ser obrigatório
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public int OrigemId { get; set; }
        public int TipoId { get; set; }

        [ForeignKey("OrigemId")]
        public Origem Origem { get; set; } // Removido o '?', já que deve ser obrigatório

        [ForeignKey("TipoId")]
        public Tipo Tipo { get; set; } // Removido o '?', já que deve ser obrigatório
    }
}
