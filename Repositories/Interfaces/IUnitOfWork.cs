namespace FPIS.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IRepositoryDelatnost RepositoryDelatnost { get; }
        Task<bool> Complete();
        bool HasChanged();
    }
}
