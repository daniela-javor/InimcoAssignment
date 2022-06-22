using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class FileManager<T> : IFileManager<T> where T : class
    {
        public async Task<T> SavePerson(T entity)
        {
            return await SaveContent(entity);
        }

        private string GetFilePath()
        {
            string location = "C:\\db";
            string databaseName = "PersonsDatabase";
            string fileType = "json";

            Directory.CreateDirectory(location);
            return Path.Combine(location, databaseName + "." + fileType);
        }

        private string LoadContent()
        {
            //TODO: lock
            string path = GetFilePath();

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return ""; 
        }

        private async Task<T> SaveContent(T entity)
        {
            //TODO: lock
            var list = await Task.Run(() => JsonConvert.DeserializeObject<List<T>>(LoadContent())) ?? new List<T>();
            list.Add(entity);
            string content = await Task.Run(() => JsonConvert.SerializeObject(list, Formatting.Indented));

            string path = GetFilePath();
            await File.WriteAllTextAsync(path, content);

            return entity;
        }
    }
}
