using System.Domain.Entities;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Repositories
{
    public interface ICashierRepository : IGenericRepository<Cashier>
    {
        Task<ResponseWrapper<int>> GetTotalPages(int pgSize);
        Task<ResponseWrapper<ICollection<Cashier>>> GetAllPaginatedAsync(int pgSize, int pgNumber);
    }
}
