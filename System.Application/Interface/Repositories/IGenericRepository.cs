using Jumify.Application.APIWrapper;

namespace System.Application.Interface.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class,new()
    {
        Task<ResponseWrapper<ICollection<TEntity>>> GetAllAsync();
        Task<ResponseWrapper<TEntity>> GetByIdAsync(long id);
        Task<ResponseWrapper<TEntity>> AddAsync(TEntity entity);
        Task<ResponseWrapper<TEntity>> UpdateAsync(TEntity entity);
        Task<ResponseWrapper<TEntity>> DeleteAsync(long id);
    }
}
