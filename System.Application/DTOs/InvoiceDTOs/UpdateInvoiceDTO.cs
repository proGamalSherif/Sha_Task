namespace System.Application.DTOs.InvoiceDTOs
{
    public class UpdateInvoiceDTO : BaseInvoiceHeaderDTO
    {
        public long ID { get; set; }
        public IList<InsertInvoiceDetailsDTO> InvoiceDetails { get; set; } = new List<InsertInvoiceDetailsDTO>();
    }
}
