using System;
using System.Collections.Generic;

namespace Istat.Models;

public partial class Provincia
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public string Sigla { get; set; } = null!;

    public int? CodiceCittaMetropolitana { get; set; }

    public int IdRegione { get; set; }

    public double SuperficieTot
    {
        get 
        {

            return Math.Round(Comunes.Sum(x => x.Superficie),2);
        }
    }

    public virtual ICollection<Comune> Comunes { get; set; } = new List<Comune>();

    public virtual Regione IdRegioneNavigation { get; set; } = null!;
}
