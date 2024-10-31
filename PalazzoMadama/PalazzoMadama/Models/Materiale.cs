using System;
using System.Collections.Generic;

namespace PalazzoMadama.Models;

public partial class Materiale
{
    public int Id { get; set; }

    public string? Denominazione { get; set; }

    public virtual ICollection<Opera> IdOperas { get; set; } = new List<Opera>();
}
