using System;
using System.Collections.Generic;

namespace WebShoppie.Persistence;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
