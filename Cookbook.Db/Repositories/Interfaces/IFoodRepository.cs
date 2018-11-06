using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface IFoodRepository : IBaseRepository<Food>, IDisposable {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food> GetAsync(long id);
        Task<long> CreateAsync(Food food);
        void Update(Food food);
        Task DeleteAsync(long id);
    }
}
