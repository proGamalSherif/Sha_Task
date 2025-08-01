namespace System.Domain.Entities;
public partial class InvoiceDetails
{
    public long ID { get; set; }
    public long InvoiceHeaderID { get; set; }
    public string ItemName { get; set; } = null!;
    public double ItemCount { get; set; }
    public double ItemPrice { get; set; }
    public virtual InvoiceHeader InvoiceHeader { get; set; } = null!;
}
