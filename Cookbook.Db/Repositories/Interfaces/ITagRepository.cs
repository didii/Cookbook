using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface ITagRepository : IBaseRepository<Tag> {
        Task<Tag> GetByName(string name);
        Task<Tag> GetAsync(long id);
        Task<long> CreateAsync(Tag entity);
        Task UpdateAsync(long id);
        void Update(Tag entity);
        Task DeleteAsync(long id);
    }
}
