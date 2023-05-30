namespace Store.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}