using System.Domain.Entities;
using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Repositories
{
    public interface IBranchRepository : IQueryRepository<Branches>
    {
        Task<ResponseWrapper<ICollection<Branches>>> GetAllByCityId(int id);
    }
}
