using System.Domain.Entities;

namespace System.Application.Interface.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<InvoiceHeader> InvoiceHeaderRepository { get; }
        IGenericRepository<InvoiceDetails> InvoiceDetailsRepository { get; }
        ICashierRepository CashierRepository { get; }
        IQueryRepository<Cities> CitiesRepository { get; }
        IBranchRepository BranchRepository { get; }
        Task SaveChangesAsync();
    }
}
