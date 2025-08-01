using System.Application.Interface.Repositories;
using System.Domain.Entities;
using System.Infrastructure.Data;
using Jumify.Application.APIWrapper;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Repositories
{
    public class InvoiceHeaderRepository(SystemDBContext db) : IGenericRepository<InvoiceHeader>
    {
        public async Task<ResponseWrapper<InvoiceHeader>> AddAsync(InvoiceHeader entity)
        {
            try
            {
                if (entity == null)
                    return ResponseWrapper<InvoiceHeader>.Failure("Invoice Header Is Empty");
                await db.InvoiceHeader.AddAsync(entity);
                return ResponseWrapper<InvoiceHeader>.Success(message: "Invoice Inserted Successfully",data:entity);
            }catch(Exception ex)
            {
                return ResponseWrapper<InvoiceHeader>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<InvoiceHeader>> DeleteAsync(long id)
        {
            try
            {
                var oldEntity = await db.InvoiceHeader
                    .FirstOrDefaultAsync(ih=>ih.ID == id);
                if (oldEntity == null)
                    return ResponseWrapper<InvoiceHeader>.Failure("No Invoice Header Found With Current Id");
                db.InvoiceHeader.Remove(oldEntity);
                return ResponseWrapper<InvoiceHeader>.Success(message: "Invoice Header Deleted Successfully", data: oldEntity);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<InvoiceHeader>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<ICollection<InvoiceHeader>>> GetAllAsync()
        {
            try
            {
                var invoices = await db.InvoiceHeader
                    .Include(d=>d.InvoiceDetails)
                    .Include(b=>b.Branch)
                    .Include(c=>c.Cashier)
                    .ToListAsync();
                if (!invoices.Any())
                    return ResponseWrapper<ICollection<InvoiceHeader>>.Failure("No Invoices Found");
                return ResponseWrapper<ICollection<InvoiceHeader>>.Success(message: "Invoices Found Successfully", invoices);
            }catch(Exception ex)
            {
                return ResponseWrapper<ICollection<InvoiceHeader>>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<InvoiceHeader>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await db.InvoiceHeader
                    .Include(d => d.InvoiceDetails)
                    .Include(b => b.Branch)
                    .Include(c => c.Cashier)
                    .FirstOrDefaultAsync(ih => ih.ID == id);
                if (entity == null)
                    return ResponseWrapper<InvoiceHeader>.Failure("No Invoice Found With Current Id");
                return ResponseWrapper<InvoiceHeader>.Success(message: "Invoice Found Successfully", data: entity);

            }catch(Exception ex)
            {
                return ResponseWrapper<InvoiceHeader>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public Task<ResponseWrapper<InvoiceHeader>> UpdateAsync(InvoiceHeader entity)
        {
            try
            {
                db.InvoiceHeader.Update(entity);
                return Task.FromResult(ResponseWrapper<InvoiceHeader>.Success("Invoice Header Updated Successfully", data: entity));
            }catch(Exception ex)
            {
                return Task.FromResult(ResponseWrapper<InvoiceHeader>.Failure($"An Internal Error Occurred ({ex.Message})"));
            }
        }
    }
}
