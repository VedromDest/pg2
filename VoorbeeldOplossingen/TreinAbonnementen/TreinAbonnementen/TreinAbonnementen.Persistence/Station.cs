using System;
using System.Collections.Generic;

namespace TreinAbonnementen.Persistence;

public partial class Station
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool HasWaitingRoom { get; set; }

    public virtual ICollection<Subscription> SubscriptionStation1s { get; set; } = new List<Subscription>();

    public virtual ICollection<Subscription> SubscriptionStation2s { get; set; } = new List<Subscription>();
}
