using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Services {
    public interface IRecipeClientService {
        Task<RecipeDto> GetAsync(long id);
    }
}
