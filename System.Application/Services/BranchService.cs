using System.Application.DTOs.BranchesDTOs;
using System.Application.Interface.Repositories;
using System.Application.Interface.Services;
using AutoMapper;
using Jumify.Application.APIWrapper;

namespace System.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public BranchService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<ResponseWrapper<ICollection<ReadBranchDTO>>> GetAllAsync()
        {
            var responseResult = await unitOfWork.BranchRepository.GetAllAsync();
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ICollection<ReadBranchDTO>>.Failure(responseResult.Message);
            var mappedOutput = mapper.Map<ICollection<ReadBranchDTO>>(responseResult.Data);
            return ResponseWrapper<ICollection<ReadBranchDTO>>.Success(responseResult.Message,data:mappedOutput);
        }
        public async Task<ResponseWrapper<ICollection<ReadBranchDTO>>> GetAllByCityId(int id)
        {
            var responseResult = await unitOfWork.BranchRepository.GetAllByCityId(id);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ICollection<ReadBranchDTO>>.Failure(responseResult.Message);
            var mappedOutput = mapper.Map<ICollection<ReadBranchDTO>>(responseResult.Data);
            return ResponseWrapper<ICollection<ReadBranchDTO>>.Success(responseResult.Message, data: mappedOutput);
        }
        public async Task<ResponseWrapper<ReadBranchDTO>> GetByIdAsync(int id)
        {
            var responseResult = await unitOfWork.BranchRepository.GetByIdAsync(id);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadBranchDTO>.Failure(responseResult.Message);
            var mappedOutput = mapper.Map<ReadBranchDTO>(responseResult.Data);
            return ResponseWrapper<ReadBranchDTO>.Success(responseResult.Message, data: mappedOutput);
        }
    }
}
