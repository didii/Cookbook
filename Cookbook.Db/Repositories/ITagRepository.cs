using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface ITagRepository : IDisposable {
        Task<long> CreateAsync(Tag entity);
        Task<Tag> GetAsync(long id);
        void Update(Tag entity);
        Task DeleteAsync(long id);
        Task SaveAsync();
    }
}
