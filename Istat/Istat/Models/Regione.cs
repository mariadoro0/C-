using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Istat.Models;

public partial class Regione
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public int IdRipartizione { get; set; }

    public string? Immagine { get; set; }


    public virtual RipartizioneGeografica IdRipartizioneNavigation { get; set; } = null!;

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
}
