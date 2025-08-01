using System.Application.Interface.Repositories;
using System.Domain.Entities;
using System.Infrastructure.Data;

namespace System.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SystemDBContext _db;
        public UnitOfWork(SystemDBContext db)
        {
            _db = db;
            InvoiceHeaderRepository = new InvoiceHeaderRepository(_db);
            InvoiceDetailsRepository = new InvoiceDetailsRepository(_db);
            CashierRepository = new CashierRepository(_db);
            CitiesRepository = new CityRepository(_db);
            BranchRepository = new BranchRepository(_db);
        }
        public IGenericRepository<InvoiceHeader> InvoiceHeaderRepository { get; }
        public IGenericRepository<InvoiceDetails> InvoiceDetailsRepository { get; }
        public ICashierRepository CashierRepository { get; }
        public IQueryRepository<Cities> CitiesRepository { get; }
        public IBranchRepository BranchRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
