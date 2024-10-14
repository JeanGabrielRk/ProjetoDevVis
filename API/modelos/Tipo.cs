using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.modelos;

public class Tipo {
    public int TipoId { get; set;}
        public string? Nome { get; set;}
            public DateTime CriadoEm { get; set;} = DateTime.Now;

    public ICollection<Planta> Plantas { get; set; } = new List<Planta>();

}

    
