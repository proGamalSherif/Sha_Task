using System;
using System.Collections.Generic;

namespace System.Domain.Entities;

public partial class Branches
{
    public int ID { get; set; }
    public string BranchName { get; set; } = null!;
    public int CityID { get; set; }
    public virtual ICollection<Cashier> Cashier { get; set; } = new List<Cashier>();
    public virtual Cities City { get; set; } = null!;
    public virtual ICollection<InvoiceHeader> InvoiceHeader { get; set; } = new List<InvoiceHeader>();
}
