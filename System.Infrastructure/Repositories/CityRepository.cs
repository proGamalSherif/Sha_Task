using System.Application.Interface.Repositories;
using System.Domain.Entities;
using System.Infrastructure.Data;
using Jumify.Application.APIWrapper;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Repositories
{
    public class CityRepository(SystemDBContext db) : IQueryRepository<Cities>
    {
        public async Task<ResponseWrapper<ICollection<Cities>>> GetAllAsync()
        {
            try
            {
                var branches = await db.Cities
                    .Include(b=>b.Branches)
                    .ToListAsync();
                if (!branches.Any())
                    return ResponseWrapper<ICollection<Cities>>.Failure("No Branches Found");
                return ResponseWrapper<ICollection<Cities>>.Success(message: "Branches Found Successfully", data: branches);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<ICollection<Cities>>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
        public async Task<ResponseWrapper<Cities>> GetByIdAsync(int Id)
        {
            try
            {
                var branch = await db.Cities
                    .Include(b=>b.Branches)
                    .FirstOrDefaultAsync(b => b.ID == Id);
                if (branch == null)
                    return ResponseWrapper<Cities>.Failure("No Branch Found For Selected Id");
                return ResponseWrapper<Cities>.Success(message: "Branch Found Successfully", data: branch);
            }
            catch (Exception ex)
            {
                return ResponseWrapper<Cities>.Failure($"An Internal Error Occurred ({ex.Message})");
            }
        }
    }
}
