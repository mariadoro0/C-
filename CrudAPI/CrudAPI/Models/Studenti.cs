using System;
using System.Collections.Generic;

namespace CrudAPI.Models;

public partial class Studenti
{
    public short Matricola { get; set; }

    public string? Nome { get; set; }

    public string? Cognome { get; set; }

    public string? Email { get; set; }

    public string? Classe { get; set; }
}
