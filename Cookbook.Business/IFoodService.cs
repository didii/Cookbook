using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Business {
    public interface IFoodService {
        Task<IEnumerable<FoodDto>> GetAll();
        Task<FoodDto> Get(int id);
        Task Create(FoodCreate food);
        Task Update(FoodUpdate food);
        Task Delete(int id);
    }
}
