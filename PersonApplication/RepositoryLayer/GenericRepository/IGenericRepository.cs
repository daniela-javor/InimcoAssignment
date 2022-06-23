namespace RepositoryLayer
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Insert(T entity);
    }
}
