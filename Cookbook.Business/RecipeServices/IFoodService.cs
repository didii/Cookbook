using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Business.RecipeServices {
    public interface IFoodService : IDisposable {
        Task<IEnumerable<FoodDto>> GetAllAsync();
        Task CreateAsync(FoodCreate food);
        Task<FoodDto> GetAsync(long id);
        Task UpdateAsync(long id, FoodUpdate food);
        Task DeleteAsync(long id);
    }
}
