﻿using System;
using System.Collections.Generic;

namespace Istat.Models;

public partial class Comune
{
    public int Id { get; set; }

    public int IdProvincia { get; set; }

    public string Denominazione { get; set; } = null!;

    public string CodiceCatastale { get; set; } = null!;

    public bool ComuneCapoluogo { get; set; }

    public int AltitudineCentro { get; set; }

    public bool ZonaLitoranea { get; set; }

    public int IdZonaAltimetrica { get; set; }

    public string IdZonaMontana { get; set; } = null!;

    public double Superficie { get; set; }

    public int Popolazione2001 { get; set; }

    public int Popolazione2011 { get; set; }

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual ZonaAltimetrica IdZonaAltimetricaNavigation { get; set; } = null!;

    public virtual ZonaMontana IdZonaMontanaNavigation { get; set; } = null!;
}
