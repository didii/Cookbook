using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface IRecipeRepository : IBaseRepository<Recipe>, IDisposable {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe> GetAsync(long id);
        Task<long> CreateAsync(Recipe recipe);
        void Update(Recipe recipe);
        Task DeleteAsync(long id);
    }
}
