using System.Application.DTOs.CashierDTOs;
using System.Application.DTOs.InvoiceDTOs;
using System.Domain.Entities;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Services
{
    public interface IInvoiceService
    {
        Task<ResponseWrapper<ICollection<ReadInvoiceDTO>>> GetAllInvoicesAsync();
        Task<ResponseWrapper<ReadInvoiceDTO>> GetInvoiceByIdAsync(long id);
        Task<ResponseWrapper<ReadInvoiceDTO>> AddInvoiceAsync(InsertInvoiceDTO invoiceDto);
        Task<ResponseWrapper<ReadInvoiceDTO>> UpdateInvoiceAsync(UpdateInvoiceDTO invoiceDto);
        Task<ResponseWrapper<bool>> DeleteInvoiceAsync(long id);
        Task<ResponseWrapper<int>> GetTotalPages(int pgSize);
        Task<ResponseWrapper<ICollection<ReadInvoiceDTO>>> GetAllPaginatedAsync(int pgSize, int pgNumber);
        Task<ResponseWrapper<ICollection<ReadInvoiceDTO>>> GetAllFilteredPaginatedAsync(int pgSize, int pgNumber, string filterText);
        Task<ResponseWrapper<int>> GetTotalFilteredPages(int pgSize, string filterText);
    }
}
