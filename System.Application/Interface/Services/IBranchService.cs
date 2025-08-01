using System.Application.DTOs.BranchesDTOs;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Services
{
    public interface IBranchService
    {
        Task<ResponseWrapper<ICollection<ReadBranchDTO>>> GetAllAsync();
        Task<ResponseWrapper<ReadBranchDTO>> GetByIdAsync(int id);
        Task<ResponseWrapper<ICollection<ReadBranchDTO>>> GetAllByCityId(int id);
    }
}
