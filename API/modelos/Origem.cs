using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class Origem {
    
    [Key]
    public int IdOrigem { get; set; }

    public string? Pais { get; set; }

    
    public ICollection<Planta> Plantas { get; set; } = new List<Planta>();

    

    
}