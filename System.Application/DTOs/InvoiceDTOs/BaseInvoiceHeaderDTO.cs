using System.ComponentModel.DataAnnotations;

namespace System.Application.DTOs.InvoiceDTOs
{
    public class BaseInvoiceHeaderDTO
    {
        public string CustomerName { get; set; }
        public int CashierID { get; set; }
        public int BranchID { get; set; }
    }
}
