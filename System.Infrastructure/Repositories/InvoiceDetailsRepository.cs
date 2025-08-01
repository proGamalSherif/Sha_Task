using System.Application.Interface.Repositories;
using System.Domain.Entities;
using System.Infrastructure.Data;
using Jumify.Application.APIWrapper;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Repositories
{
    public class InvoiceDetailsRepository(SystemDBContext db) : IGenericRepository<InvoiceDetails>
    {
        public async Task<ResponseWrapper<InvoiceDetails>> AddAsync(InvoiceDetails entity)
        {
            try
            {
                if (entity == null)
                    return ResponseWrapper<InvoiceDetails>.Failure("Invoice Detail Is Empty");
                await db.InvoiceDetails.AddAsync(entity);
                return ResponseWrapper<InvoiceDetails>.Success(message: "Invoice Detail Inserted Successfully", data: entity);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<InvoiceDetails>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<InvoiceDetails>> DeleteAsync(long id)
        {
            try
            {
                var oldEntity = await db.InvoiceDetails.FirstOrDefaultAsync(ih => ih.ID == id);
                if (oldEntity == null)
                    return ResponseWrapper<InvoiceDetails>.Failure("No Invoice Detail Found With Current Id");

                db.InvoiceDetails.Remove(oldEntity);
                return ResponseWrapper<InvoiceDetails>.Success(message: "Invoice Detail Deleted Successfully", data: oldEntity);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<InvoiceDetails>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<ICollection<InvoiceDetails>>> GetAllAsync()
        {
            try
            {
                var details = await db.InvoiceDetails.ToListAsync();
                if (!details.Any())
                    return ResponseWrapper<ICollection<InvoiceDetails>>.Failure("No Invoice Details Found");

                return ResponseWrapper<ICollection<InvoiceDetails>>.Success(message: "Invoice Details Found Successfully", details);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<ICollection<InvoiceDetails>>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<InvoiceDetails>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await db.InvoiceDetails.FirstOrDefaultAsync(ih => ih.ID == id);
                if (entity == null)
                    return ResponseWrapper<InvoiceDetails>.Failure("No Invoice Detail Found With Current Id");

                return ResponseWrapper<InvoiceDetails>.Success(message: "Invoice Detail Found Successfully", data: entity);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<InvoiceDetails>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public Task<ResponseWrapper<InvoiceDetails>> UpdateAsync(InvoiceDetails entity)
        {
            try
            {
                db.InvoiceDetails.Update(entity);
                return Task.FromResult(ResponseWrapper<InvoiceDetails>.Success("Invoice Detail Updated Successfully", data: entity));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResponseWrapper<InvoiceDetails>.Failure($"An Internal Error Occurred ({ex.Message})"));
            }
        }
    }

}
