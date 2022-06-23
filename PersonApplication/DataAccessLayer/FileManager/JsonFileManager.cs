using Newtonsoft.Json;
using System.IO.Abstractions;

namespace DataAccessLayer
{
    /// <summary>
    /// Represents class used for saving entities to json file on file system.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public class JsonFileManager<T> : IFileManager<T> where T : class
    {
        private readonly IFileSystem _fileSystem;
        private string _path;
        private SemaphoreSlim _lockObject;

        /// <summary>
        /// JsonFileManager constructor.
        /// </summary>
        /// <param name="fileSystem">File system interface.</param>
        /// <param name="path">Full path to json file on file system.</param>
        public JsonFileManager(IFileSystem fileSystem, string path)
        {
            _fileSystem = fileSystem;
            _path = path;
            _lockObject = new SemaphoreSlim(1);
        }

        /// <summary>
        /// Saves entity to json file.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        /// <returns>Returns saved entity.</returns>
        public async Task<T> SaveEntity(T entity)
        {
            await _lockObject.WaitAsync();

            try
            {
                await SaveContent(entity);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _lockObject.Release();
            }

            return entity;
        }

        /// <summary>
        /// Loads content from file.
        /// </summary>
        /// <returns>Returns loaded file as string.</returns>
        private string LoadContent()
        {
            string content = "";

            if (_fileSystem.File.Exists(_path))
            {
                content = _fileSystem.File.ReadAllText(_path);
            }

            return content;
        }

        /// <summary>
        /// Saves entity to json file.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        /// <returns>Async task.</returns>
        private async Task SaveContent(T entity)
        {
            _fileSystem.Directory.CreateDirectory(new DirectoryInfo(_path).Name);
            string content = LoadContent();
            var list = await Task.Run(() => JsonConvert.DeserializeObject<List<T>>(content)) ?? new List<T>();
            list.Add(entity);
            content = await Task.Run(() => JsonConvert.SerializeObject(list, Formatting.Indented));
            await _fileSystem.File.WriteAllTextAsync(_path, content);
        }
    }
}
