using System;
using System.Collections.Generic;

namespace Task_Auth.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Tipo { get; set; } = "USER";
}
