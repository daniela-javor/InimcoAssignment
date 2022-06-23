namespace RepositoryLayer
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Creates entity and calls data layer for saving entity.
        /// </summary>
        /// <param name="entity">Entity for saving.</param>
        /// <returns>Async task.</returns>
        Task<T> CreateEntity(T entity);
    }
}
