namespace System.Application.DTOs.InvoiceDTOs
{
    public class BaseInvoiceDetailsDTO
    {
        public long InvoiceHeaderID { get; set; }
        public string ItemName { get; set; }
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }
    }
}
