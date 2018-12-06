using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Cookbook.Web.Client.Services {
    public interface IRecipeClientService {
        Task<RecipeDto> GetAsync(long id);
        Task<RecipeDto> PatchAsync(long id, IEnumerable<Operation<RecipeUpdate>> ops);
    }
}
