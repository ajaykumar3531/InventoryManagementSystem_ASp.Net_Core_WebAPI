using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL.Contracts
{
    public interface IDataAccess<T> where T : class
    {
        Task<List<T>> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<bool> SaveChangesAsync();
        Task<T> GetById(int id);
    }
}
