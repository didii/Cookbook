using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    internal interface IBaseRepository<T> : IDisposable where T : class, IDbItem {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task<long> CreateAsync(T entity);
        void Update(T food);
        Task DeleteAsync(long id);
        Task SaveAsync();
    }
}