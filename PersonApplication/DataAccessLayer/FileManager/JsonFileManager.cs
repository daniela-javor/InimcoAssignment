using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class JsonFileManager<T> : IFileManager<T> where T : class
    {
        private SemaphoreSlim _lockObject;
        private string _path;

        public JsonFileManager(string path)
        {
            _lockObject = new SemaphoreSlim(1);
            _path = path;
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

            if (File.Exists(_path))
            {
                content = File.ReadAllText(_path);
            }

            return content;
        }

        private async Task SaveContent(T entity)
        {
            Directory.CreateDirectory(new DirectoryInfo(_path).Name);
            string content = LoadContent();
            var list = await Task.Run(() => JsonConvert.DeserializeObject<List<T>>(content)) ?? new List<T>();
            list.Add(entity);
            content = await Task.Run(() => JsonConvert.SerializeObject(list, Formatting.Indented));
            await File.WriteAllTextAsync(_path, content);
        }
    }
}
