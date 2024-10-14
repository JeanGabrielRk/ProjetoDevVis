using System;

namespace API.modelos;

public class Tipo
{
    public int TipoId { get; set;}
        public string? Nome { get; set;}
            public DateTime CrriadoEm { get; set;} = DateTime.Now;

}
