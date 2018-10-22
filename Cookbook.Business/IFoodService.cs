using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Business {
    public interface IFoodService {
        Task<IEnumerable<FoodDto>> GetAllAsync();
        Task<FoodDto> GetAsync(int id);
        Task CreateAsync(FoodCreate food);
        Task UpdateAsync(int id, FoodUpdate food);
        Task DeleteAsync(int id);
    }
}
