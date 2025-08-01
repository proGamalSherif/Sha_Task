using System.Application.DTOs.BranchesDTOs;
using System.Application.Interface.Repositories;
using System.Application.Interface.Services;
using AutoMapper;
using Jumify.Application.APIWrapper;

namespace System.Application.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CitiesService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<ResponseWrapper<ICollection<ReadCitiesDTO>>> GetAllAsync()
        {
            var responseResult = await unitOfWork.CitiesRepository.GetAllAsync();
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ICollection<ReadCitiesDTO>>.Failure(responseResult.Message);
            var mappedOutput = mapper.Map<ICollection<ReadCitiesDTO>>(responseResult.Data);
            return ResponseWrapper<ICollection<ReadCitiesDTO>>.Success(responseResult.Message, data: mappedOutput);
        }
        public async Task<ResponseWrapper<ReadCitiesDTO>> GetByIdAsync(int id)
        {
            var responseResult = await unitOfWork.CitiesRepository.GetByIdAsync(id);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadCitiesDTO>.Failure(responseResult.Message);
            var mappedOutput = mapper.Map<ReadCitiesDTO>(responseResult.Data);
            return ResponseWrapper<ReadCitiesDTO>.Success(responseResult.Message, data: mappedOutput);
        }
    }
}
