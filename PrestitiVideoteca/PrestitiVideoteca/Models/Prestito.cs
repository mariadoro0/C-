﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrestitiVideoteca.Models;

public partial class Prestito
{
    public int Id { get; set; }
    [DisplayName("Film")]
    public int IdFilm { get; set; }
    [DisplayName("Studente")]
    public int Matricola { get; set; }
    [DisplayName("Data Prestito")]
    public DateTime DataPrestito { get; set; }
    [DisplayName("Data Scadenza")]
    public DateTime DataScadenza { get => DataPrestito.AddDays(30); }
    [DisplayName("Data Restituzione")]
    public DateTime? DataRestituzione { get; set; }
    [DisplayName("Film")]
    public virtual Film IdFilmNavigation { get; set; } = null!;
    [DisplayName("Studente")]
    public virtual Studente MatricolaNavigation { get; set; } = null!;
}
