namespace System.Application.DTOs.InvoiceDTOs
{
    public class InsertInvoiceDTO : BaseInvoiceHeaderDTO
    {
        public IList<InsertInvoiceDetailsDTO> InvoiceDetails { get; set; } = new List<InsertInvoiceDetailsDTO>();
    }
}
