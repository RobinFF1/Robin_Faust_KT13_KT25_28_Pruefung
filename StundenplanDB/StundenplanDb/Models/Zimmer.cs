using System;
using System.Collections.Generic;

namespace StundenplanDb.Models;

public partial class Zimmer
{
    public int ZimmerId { get; set; }

    public string Bezeichnung { get; set; } = null!;

    public virtual ICollection<StundenplanEintraege> StundenplanEintraeges { get; set; } = new List<StundenplanEintraege>();
}
