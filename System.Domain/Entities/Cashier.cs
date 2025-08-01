using System;
using System.Collections.Generic;
namespace System.Domain.Entities;
public partial class Cashier
{
    public int ID { get; set; }
    public string CashierName { get; set; } = null!;
    public int BranchID { get; set; }
    public virtual Branches Branch { get; set; } = null!;
    public virtual ICollection<InvoiceHeader> InvoiceHeader { get; set; } = new List<InvoiceHeader>();
}
