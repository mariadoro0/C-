using System;
using System.Collections.Generic;

namespace GamCollezioni.Models;

public partial class Opera
{
    public int Id { get; set; }

    public string? Autore { get; set; }

    public string? Titolo { get; set; }

    public string? Datazione { get; set; }

    public string? Tecnica { get; set; }

    public string? Dimensioni { get; set; }

    public string? Immagine { get; set; }
}
