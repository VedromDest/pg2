using System;
using System.Collections.Generic;

namespace TreinAbonnementen.Persistence;

public partial class Subscription
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int Station1Id { get; set; }

    public int Station2Id { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public int ComfortLevel { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Station Station1 { get; set; } = null!;

    public virtual Station Station2 { get; set; } = null!;
}
