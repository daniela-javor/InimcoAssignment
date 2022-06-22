using Microsoft.EntityFrameworkCore;
using DataAccessLayer;

namespace RepositoryLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IFileManager<T> _fileManager;

        public GenericRepository(IFileManager<T> fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<T> Insert(T entity)
        {
            return await _fileManager.SavePerson(entity);
        }
    }
}
