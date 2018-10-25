using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface IFoodRepository : IDisposable {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food> GetAsync(long id);
        Task AddAsync(Food food);
        Task UpdateAsync(Food food);
        Task DeleteAsync(long id);
        Task SaveAsync();
    }
}
