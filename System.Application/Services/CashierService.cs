using System.Application.DTOs.CashierDTOs;
using System.Application.Interface.Repositories;
using System.Application.Interface.Services;
using System.Domain.Entities;
using AutoMapper;
using Jumify.Application.APIWrapper;

namespace System.Application.Services
{
    public class CashierService : ICashierService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CashierService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<ResponseWrapper<ReadCashierDTO>> DeleteAsync(int id)
        {
            var oldEntity = await unitOfWork.CashierRepository.GetByIdAsync(id);
            if (!oldEntity.IsSuccess)
                return ResponseWrapper<ReadCashierDTO>.Failure(oldEntity.Message);
            if (oldEntity.Data.InvoiceHeader.Count() > 0)
                return ResponseWrapper<ReadCashierDTO>.Failure("Selected Cashier Are Currently Can not be deleted because it already have invoices created");
            var responseResult = await unitOfWork.CashierRepository.DeleteAsync(id);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadCashierDTO>.Failure(responseResult.Message);
            await unitOfWork.SaveChangesAsync();
            var mappedOutput = mapper.Map<ReadCashierDTO>(responseResult.Data);
            return ResponseWrapper<ReadCashierDTO>.Success(message: responseResult.Message, mappedOutput);
        }
        public async Task<ResponseWrapper<ICollection<ReadCashierDTO>>> GetAllAsync()
        {
            var responseResult = await unitOfWork.CashierRepository.GetAllAsync();
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ICollection<ReadCashierDTO>>.Failure(responseResult.Message);
            await unitOfWork.SaveChangesAsync();
            var mappedOutput = mapper.Map<ICollection<ReadCashierDTO>>(responseResult.Data);
            return ResponseWrapper<ICollection<ReadCashierDTO>>.Success(message: responseResult.Message, mappedOutput);
        }
        public async Task<ResponseWrapper<ReadCashierDTO>> GetByIdAsync(int id)
        {
            var responseResult = await unitOfWork.CashierRepository.GetByIdAsync(id);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadCashierDTO>.Failure(responseResult.Message);
            await unitOfWork.SaveChangesAsync();
            var mappedOutput = mapper.Map<ReadCashierDTO>(responseResult.Data);
            return ResponseWrapper<ReadCashierDTO>.Success(message: responseResult.Message, mappedOutput);
        }
        public async Task<ResponseWrapper<ReadCashierDTO>> InsertAsync(InsertCashierDTO entity)
        {
            var mappedInput = mapper.Map<Cashier>(entity);
            var responseResult = await unitOfWork.CashierRepository.AddAsync(mappedInput);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadCashierDTO>.Failure(responseResult.Message);
            await unitOfWork.SaveChangesAsync();
            var mappedOutput = mapper.Map<ReadCashierDTO>(responseResult.Data);
            return ResponseWrapper<ReadCashierDTO>.Success(message: responseResult.Message, data: mappedOutput);
        }
        public async Task<ResponseWrapper<ReadCashierDTO>> UpdateAsync(UpdateCashierDTO entity)
        {
            var mappedInput = mapper.Map<Cashier>(entity);
            var responseResult = await unitOfWork.CashierRepository.UpdateAsync(mappedInput);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadCashierDTO>.Failure(responseResult.Message);
            await unitOfWork.SaveChangesAsync();
            var mappedOutput = mapper.Map<ReadCashierDTO>(responseResult.Data);
            return ResponseWrapper<ReadCashierDTO>.Success(message: responseResult.Message, data: mappedOutput);
        }
    }
}
