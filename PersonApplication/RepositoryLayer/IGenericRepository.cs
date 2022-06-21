namespace RepositoryLayer
{
    public interface IGenericRepository<T> where T : class
    {
        Task Insert(T entity);
        Task Save();
    }
}
