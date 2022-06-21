using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FileManager<T> : IFileManager<T> where T : class
    {
        public async Task<T> AppendContent(T entity)
        {
            //Save to file stream async
            return entity;
        }
    }
}
