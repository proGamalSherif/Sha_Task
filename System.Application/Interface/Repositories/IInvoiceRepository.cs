using System.Domain.Entities;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Repositories
{
    public interface IInvoiceRepository : IGenericRepository<InvoiceHeader>
    {
        Task<ResponseWrapper<int>> GetTotalPages(int pgSize);
        Task<ResponseWrapper<ICollection<InvoiceHeader>>> GetAllPaginatedAsync(int pgSize, int pgNumber);
        Task<ResponseWrapper<ICollection<InvoiceHeader>>> GetAllFilteredPaginatedAsync(int pgSize, int pgNumber, string filterText);
        Task<ResponseWrapper<int>> GetTotalFilteredPages(int pgSize, string filterText);
    }
}
