using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FileManager<T> : IFileManager<T> where T : class
    {
        public async Task<T> SavePerson(T entity)
        {
            var list = JsonConvert.DeserializeObject<List<T>>(LoadContent());
            if (list == null)
                list = new List<T>();
            list.Add(entity);
            SaveContent(JsonConvert.SerializeObject(list, Formatting.Indented));

            return entity;
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

        private void SaveContent(string content)
        {
            //TODO: lock
            string path = GetFilePath();
            File.WriteAllText(path, content);
        }
    }
}
