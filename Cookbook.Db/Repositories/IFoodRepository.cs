using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface IFoodRepository {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food> GetAsync(int id);
        Task AddAsync(Food food);
        Task UpdateAsync(Food food);
        Task DeleteAsync(int id);
    }
}
