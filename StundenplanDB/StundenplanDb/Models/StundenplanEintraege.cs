using System;
using System.Collections.Generic;

namespace StundenplanDb.Models;

public partial class StundenplanEintraege
{
    public int EintragId { get; set; }

    public int KlasseId { get; set; }

    public int LehrerId { get; set; }

    public int ZimmerId { get; set; }

    public DateOnly Datum { get; set; }

    public TimeOnly Uhrzeit { get; set; }

    public virtual Klassen Klasse { get; set; } = null!;

    public virtual Lehrer Lehrer { get; set; } = null!;

    public virtual Zimmer Zimmer { get; set; } = null!;
}
