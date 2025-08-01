using System.Application.Interface.Repositories;
using System.Domain.Entities;
using System.Infrastructure.Data;
using Jumify.Application.APIWrapper;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Repositories
{
    public class CashierRepository(SystemDBContext db) : IGenericRepository<Cashier>
    {
        public async Task<ResponseWrapper<Cashier>> AddAsync(Cashier entity)
        {
            try
            {
                if (entity == null)
                    return ResponseWrapper<Cashier>.Failure("Entity Is Empty");
                await db.Cashier.AddAsync(entity);
                return ResponseWrapper<Cashier>.Success("Entity Inserted Successfully", data: entity);
            }catch(Exception ex)
            {
                return ResponseWrapper<Cashier>.Failure($"An Internal Error occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<Cashier>> DeleteAsync(long id)
        {
            try
            {
                var oldEntity = await db.Cashier
                     .FirstOrDefaultAsync(c => c.ID == id);
                if (oldEntity == null)
                    return ResponseWrapper<Cashier>.Failure("No Entity Found With Current Id");
                db.Cashier.Remove(oldEntity);
                return ResponseWrapper<Cashier>.Success(message: "Entity Deleted Successfully", data: oldEntity);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<Cashier>.Failure($"An Internal Error occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<ICollection<Cashier>>> GetAllAsync()
        {
            try
            {
                var cashiers = await db.Cashier
                    .Include(b => b.Branch)
                    .Include(i=>i.InvoiceHeader)
                    .ThenInclude(id=>id.InvoiceDetails)
                    .ToListAsync();
                if (!cashiers.Any())
                    return ResponseWrapper<ICollection<Cashier>>.Failure("No Entities Found");
                return ResponseWrapper<ICollection<Cashier>>.Success(message: "Entities Found Successfully", data: cashiers);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<ICollection<Cashier>>.Failure($"An Internal Error occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<Cashier>> GetByIdAsync(long id)
        {
            try
            {
                var cashier = await db.Cashier
                    .Include(b => b.Branch)
                    .Include(i => i.InvoiceHeader)
                    .ThenInclude(id => id.InvoiceDetails)
                     .FirstOrDefaultAsync(c => c.ID == id);
                if (cashier == null)
                    return ResponseWrapper<Cashier>.Failure("No Entity Found With Current Id");
                return ResponseWrapper<Cashier>.Success(message:"Entity Found Successfully",data: cashier);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<Cashier>.Failure($"An Internal Error occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<Cashier>> UpdateAsync(Cashier entity)
        {
            try
            {
                var oldEntity = await db.Cashier
                     .FirstOrDefaultAsync(c => c.ID == entity.ID);
                if (oldEntity == null)
                    return ResponseWrapper<Cashier>.Failure("No Entity Found To Update");
                db.Entry(oldEntity).CurrentValues.SetValues(entity);
                return ResponseWrapper<Cashier>.Success("Entity Updated Successfully", data: entity);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<Cashier>.Failure($"An Internal Error occurred ({ex.Message})");
            }
        }
    }
}
