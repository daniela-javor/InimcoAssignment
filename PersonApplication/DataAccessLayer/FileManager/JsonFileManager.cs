using Newtonsoft.Json;
using System.IO.Abstractions;

namespace DataAccessLayer
{
    public class JsonFileManager<T> : IFileManager<T> where T : class
    {
        private readonly IFileSystem _fileSystem;
        private string _path;
        private SemaphoreSlim _lockObject;

        public JsonFileManager(IFileSystem fileSystem, string path)
        {
            _fileSystem = fileSystem;
            _path = path;
            _lockObject = new SemaphoreSlim(1);
        }

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

        private string LoadContent()
        {
            string content = "";

            if (_fileSystem.File.Exists(_path))
            {
                content = _fileSystem.File.ReadAllText(_path);
            }

            return content;
        }

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
