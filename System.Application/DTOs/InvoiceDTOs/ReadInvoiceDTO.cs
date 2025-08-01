namespace System.Application.DTOs.InvoiceDTOs
{
    public class ReadInvoiceDTO : BaseInvoiceHeaderDTO
    {
        public long ID { get; set; }
        public DateTime Invoicedate { get; set; }
        public string? CashierName { get; set; }
        public string BranchName { get; set; }
        public IList<ReadInvoiceDetailsDTO> InvoiceDetails { get; set; } = new List<ReadInvoiceDetailsDTO>();
        public double TotalPrice => InvoiceDetails?.Sum(x => x.ItemPrice * x.ItemCount) ?? 0;
    }
}
