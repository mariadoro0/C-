﻿using System;
using System.Collections.Generic;

namespace ScuoleItaliane.Models;

public partial class RipartizioneGeografica
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public virtual ICollection<Regione> Regioni { get; set; } = new List<Regione>();
}
