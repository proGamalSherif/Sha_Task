using System.Application.DTOs.BranchesDTOs;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Services
{
    public interface ICitiesService
    {
        Task<ResponseWrapper<ICollection<ReadCitiesDTO>>> GetAllAsync();
        Task<ResponseWrapper<ReadCitiesDTO>> GetByIdAsync(int id);
    }
}
