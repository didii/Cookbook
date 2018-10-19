using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface IFoodRepository {
        Task<IEnumerable<Food>> GetAll();
        Task<Food> Get(int id);
        Task Add(Food food);
        Task Update(Food food);
        Task Delete(int id);
    }
}
