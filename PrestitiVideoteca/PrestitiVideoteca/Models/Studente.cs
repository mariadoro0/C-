﻿using System;
using System.Collections.Generic;

namespace PrestitiVideoteca.Models;

public partial class Studente
{
    public int Matricola { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Classe { get; set; } = null!;

    public string Nominativo { get => $"{Cognome} {Nome}"; }
    public virtual ICollection<Prestito> Prestiti { get; set; } = new List<Prestito>();
}
