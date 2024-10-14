using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Origem {
    
    [Key]
    public int IdOrigem { get; set; }

    public string? Pais { get; set; }

    public int IdPlanta { get; set; }

    
}