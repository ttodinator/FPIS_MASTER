using FPIS.Entities;
using FPIS.Repositories.Interfaces;

namespace FPIS.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;
        public UnitOfWork(Context context)
        {
            this.context = context;
        }
        public IRepositoryDelatnost RepositoryDelatnost => new RepositoryDelatnost(context);

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public bool HasChanged()
        {
            throw new NotImplementedException();
        }
    }
}
