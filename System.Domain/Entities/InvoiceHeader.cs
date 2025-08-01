using System;
using System.Collections.Generic;

namespace System.Domain.Entities;

public partial class InvoiceHeader
{
    public long ID { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime Invoicedate { get; set; }
    public int? CashierID { get; set; }
    public int BranchID { get; set; }
    public virtual Branches Branch { get; set; } = null!;
    public virtual Cashier? Cashier { get; set; }
    public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; } = new List<InvoiceDetails>();
}
