using System.Application.DTOs.InvoiceDTOs;
using System.Application.Interface.Repositories;
using System.Application.Interface.Services;
using System.Domain.Entities;
using AutoMapper;
using Jumify.Application.APIWrapper;

namespace System.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public InvoiceService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<ResponseWrapper<ReadInvoiceDTO>> AddInvoiceAsync(InsertInvoiceDTO invoiceDto)
        {
            var header = mapper.Map<InvoiceHeader>(invoiceDto);
            var responseResult = await unitOfWork.InvoiceHeaderRepository.AddAsync(header);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadInvoiceDTO>.Failure(responseResult.Message);
            await unitOfWork.SaveChangesAsync();
            var insertedEntity = await unitOfWork.InvoiceHeaderRepository.GetByIdAsync(responseResult.Data.ID);
            var mappedOutput = mapper.Map<ReadInvoiceDTO>(insertedEntity.Data);
            return ResponseWrapper<ReadInvoiceDTO>.Success("Invoice added successfully", mappedOutput);
        }
        public async Task<ResponseWrapper<bool>> DeleteInvoiceAsync(long id)
        {
            var oldEntity = await unitOfWork.InvoiceHeaderRepository.GetByIdAsync(id);
            if (!oldEntity.IsSuccess)
                return ResponseWrapper<bool>.Failure(oldEntity.Message);
            var invoiceDetails = oldEntity.Data.InvoiceDetails;
            foreach(var item in invoiceDetails )
            {
                await unitOfWork.InvoiceDetailsRepository.DeleteAsync(item.ID);
            }
            await unitOfWork.SaveChangesAsync();
            var responseResult = await unitOfWork.InvoiceHeaderRepository.DeleteAsync(id);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<bool>.Failure(responseResult.Message);
            await unitOfWork.SaveChangesAsync();
            return ResponseWrapper<bool>.Success(message: responseResult.Message,data:true);
        }
        public async Task<ResponseWrapper<ICollection<ReadInvoiceDTO>>> GetAllInvoicesAsync()
        {
            var responseResult = await unitOfWork.InvoiceHeaderRepository.GetAllAsync();
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ICollection<ReadInvoiceDTO>>.Failure(responseResult.Message);
            var mappedOutput = mapper.Map<ICollection<ReadInvoiceDTO>>(responseResult.Data);
            return ResponseWrapper<ICollection<ReadInvoiceDTO>>.Success(message: responseResult.Message, data: mappedOutput);
        }
        public async Task<ResponseWrapper<ReadInvoiceDTO>> GetInvoiceByIdAsync(long id)
        {
            var responseResult = await unitOfWork.InvoiceHeaderRepository.GetByIdAsync(id);
            if (!responseResult.IsSuccess)
                return ResponseWrapper<ReadInvoiceDTO>.Failure(responseResult.Message);
            var mappedOutput = mapper.Map<ReadInvoiceDTO>(responseResult.Data);
            return ResponseWrapper<ReadInvoiceDTO>.Success(message: responseResult.Message,data: mappedOutput);
        }
        public async Task<ResponseWrapper<ReadInvoiceDTO>> UpdateInvoiceAsync(UpdateInvoiceDTO invoiceDto)
        {
            if (invoiceDto.ID <= 0)
                return ResponseWrapper<ReadInvoiceDTO>.Failure("Invoice Id Should be more than zero");
            var oldEntityResult = await unitOfWork.InvoiceHeaderRepository.GetByIdAsync(invoiceDto.ID);
            if (!oldEntityResult.IsSuccess)
                return ResponseWrapper<ReadInvoiceDTO>.Failure(oldEntityResult.Message);
            var oldEntity = oldEntityResult.Data;
            oldEntity.CustomerName = invoiceDto.CustomerName;
            oldEntity.BranchID = invoiceDto.BranchID;
            oldEntity.CashierID = invoiceDto.CashierID;
            var oldItems = oldEntity.InvoiceDetails?.ToList() ?? new List<InvoiceDetails>();
            foreach (var item in oldItems)
                await unitOfWork.InvoiceDetailsRepository.DeleteAsync(item.ID);
            var newItems = mapper.Map<ICollection<InvoiceDetails>>(invoiceDto.InvoiceDetails);
            foreach (var item in newItems)
                item.InvoiceHeaderID = invoiceDto.ID;
            foreach (var item in newItems)
                await unitOfWork.InvoiceDetailsRepository.AddAsync(item);
            await unitOfWork.SaveChangesAsync();
            var insertedEntity = await unitOfWork.InvoiceHeaderRepository.GetByIdAsync(invoiceDto.ID);
            var mappedOutput = mapper.Map<ReadInvoiceDTO>(insertedEntity.Data);
            return ResponseWrapper<ReadInvoiceDTO>.Success("Invoice updated successfully", mappedOutput);
        }
    }
}
