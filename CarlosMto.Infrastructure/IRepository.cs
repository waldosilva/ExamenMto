using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosMto.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetAsync(int id);

        Task<List<T>> GetByRange(IDictionary<string, string> parameters);
        Task<List<T>> GetAll();

    }
}
