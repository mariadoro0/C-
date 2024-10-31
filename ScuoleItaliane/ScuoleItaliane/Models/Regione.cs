using System;
using System.Collections.Generic;

namespace ScuoleItaliane.Models;

public partial class Regione
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public int IdRipartizione { get; set; }

    public virtual RipartizioneGeografica IdRipartizioneNavigation { get; set; } = null!;

    public virtual ICollection<Provincia> Province { get; set; } = new List<Provincia>();
}
