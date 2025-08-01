using System.Domain.Entities;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Repositories
{
    public interface IInvoiceRepository : IGenericRepository<InvoiceHeader>
    {
        Task<ResponseWrapper<int>> GetTotalPages(int pgSize);
        Task<ResponseWrapper<ICollection<InvoiceHeader>>> GetAllPaginatedAsync(int pgSize, int pgNumber);
    }
}
