using System;
using System.Collections.Generic;

namespace PalazzoMadama.Models;

public partial class Opera
{
    public int Id { get; set; }

    public string? Inventario { get; set; }

    public int? IdAutore { get; set; }

    public string? AmbitoCulturale { get; set; }

    public string? Datazione { get; set; }

    public string? TitoloSoggetto { get; set; }

    public string? Immagine { get; set; }

    public string? Lsreferenceby { get; set; }

    public virtual Autore? IdAutoreNavigation { get; set; }

    public virtual ICollection<Materiale> IdMateriales { get; set; } = new List<Materiale>();
}
