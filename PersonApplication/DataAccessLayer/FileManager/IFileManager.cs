using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IFileManager<T> where T : class
    {
        Task<T> AppendContent(T entity);
    }
}
