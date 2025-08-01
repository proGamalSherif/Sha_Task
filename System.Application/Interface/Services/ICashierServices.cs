using System.Application.DTOs.CashierDTOs;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Services
{
    public interface ICashierService
    {
        Task<ResponseWrapper<ICollection<ReadCashierDTO>>> GetAllAsync();
        Task<ResponseWrapper<ReadCashierDTO>> GetByIdAsync(int id);
        Task<ResponseWrapper<ReadCashierDTO>> InsertAsync(InsertCashierDTO entity);
        Task<ResponseWrapper<ReadCashierDTO>> UpdateAsync(UpdateCashierDTO entity);
        Task<ResponseWrapper<ReadCashierDTO>> DeleteAsync(int id);
        Task<ResponseWrapper<int>> GetTotalPages(int pgSize);
        Task<ResponseWrapper<ICollection<ReadCashierDTO>>> GetAllPaginatedAsync(int pgSize, int pgNumber);
    }
}
