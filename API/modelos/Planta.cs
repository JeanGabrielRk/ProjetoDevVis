using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Planta
{
    [Key]
    public int IdPlanta { get; set; }
    public string? Nome { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.Now;

    public int OrigemId { get; set; }

    public required Origem Origem { get; set; }
    
}
