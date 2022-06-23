using DataAccessLayer;

namespace RepositoryLayer
{
    /// <summary>
    /// Generic repository class.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IFileManager<T> _fileManager;

        /// <summary>
        /// Generic repository constructor.
        /// </summary>
        /// <param name="fileManager">IFileManager instance.</param>
        public GenericRepository(IFileManager<T> fileManager)
        {
            _fileManager = fileManager;
        }

        /// <summary>
        /// Creates entity and calls data layer for saving entity.
        /// </summary>
        /// <param name="entity">Entity for saving.</param>
        /// <returns>Async task.</returns>
        public async Task<T> CreateEntity(T entity)
        {
            return await _fileManager.SaveEntity(entity);
        }
    }
}
