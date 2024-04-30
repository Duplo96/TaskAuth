﻿using System;
using System.Collections.Generic;

namespace Task_Auth.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Codice { get; set; } = Guid.NewGuid().ToString();

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public string Categoria { get; set; } = null!;
}
