using System;
using System.Collections.Generic;

namespace AnagraficaAPI.Models;

public partial class Studente
{
    public short Matricola { get; set; }

    public string? Cognome { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataNascita { get; set; }

    public string? LuogoNascita { get; set; }

    public string? Via { get; set; }

    public string? Cap { get; set; }

    public string? Citta { get; set; }

    public string? SiglaProvincia { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? TitoloStudio { get; set; }
}
