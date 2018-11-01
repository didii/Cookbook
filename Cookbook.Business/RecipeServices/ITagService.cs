using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Business.RecipeServices {
    public interface ITagService {
        Task<long> CreateAsync(TagEdit tag);
        Task UpdateAsync(long id, TagEdit tag);
        Task DeleteAsync(long id);
    }
}
