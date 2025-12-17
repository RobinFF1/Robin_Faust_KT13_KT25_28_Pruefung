using System;
using System.Collections.Generic;

namespace StundenplanDb.Models;

public partial class Klassen
{
    public int KlasseId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StundenplanEintraege> StundenplanEintraeges { get; set; } = new List<StundenplanEintraege>();
}
