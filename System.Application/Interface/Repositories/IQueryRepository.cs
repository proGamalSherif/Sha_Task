using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Repositories
{
    public interface IQueryRepository<TEntity> where TEntity : class,new()
    {
        Task<ResponseWrapper<ICollection<TEntity>>> GetAllAsync();
        Task<ResponseWrapper<TEntity>> GetByIdAsync(int Id);
    }
}
