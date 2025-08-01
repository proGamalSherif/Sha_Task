using System.Application.Interface.Repositories;
using System.Domain.Entities;
using System.Infrastructure.Data;
using Jumify.Application.APIWrapper;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Repositories
{
    public class BranchRepository(SystemDBContext db) : IBranchRepository
    {
        public async Task<ResponseWrapper<ICollection<Branches>>> GetAllAsync()
        {
            try
            {
                var branches = await db.Branches
                    .Include(c=>c.City)
                    .ToListAsync();
                if (!branches.Any())
                    return ResponseWrapper<ICollection<Branches>>.Failure("No Branches Found");
                return ResponseWrapper<ICollection<Branches>>.Success(message: "Branches Found Successfully", data: branches);
            } catch (Exception ex)
            {
                return ResponseWrapper<ICollection<Branches>>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<ICollection<Branches>>> GetAllByCityId(int id)
        {
            try
            {
                var branches = await db.Branches
                    .Include(c => c.City)
                    .Where(c=>c.CityID == id)
                    .ToListAsync();
                if (!branches.Any())
                    return ResponseWrapper<ICollection<Branches>>.Failure("No Branches Found");
                return ResponseWrapper<ICollection<Branches>>.Success(message: "Branches Found Successfully", data: branches);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<ICollection<Branches>>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<Branches>> GetByIdAsync(int Id)
        {
            try
            {
                var branch = await db.Branches
                    .Include(c => c.City)
                    .FirstOrDefaultAsync(b => b.ID == Id);
                if (branch == null)
                    return ResponseWrapper<Branches>.Failure("No Branch Found For Selected Id");
                return ResponseWrapper<Branches>.Success(message: "Branch Found Successfully", data: branch);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<Branches>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
    }
}
