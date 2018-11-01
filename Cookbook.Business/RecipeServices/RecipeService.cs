using System;
using System.Threading.Tasks;
using AutoMapper;
using Cookbook.Db.Repositories;
using Cookbook.Domain;
using Cookbook.Dtos;

namespace Cookbook.Business.RecipeServices {
    internal class RecipeService : IRecipeService {
        private readonly IRecipeRepository _repo;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }
        /// <inheritdoc />
        public async Task<RecipeDto> GetAsync(long id) {
            var entity = await _repo.GetAsync(id);
            var model = _mapper.Map<RecipeDto>(entity);
            return model;
        }

        /// <inheritdoc />
        public async Task<long> CreateEmptyAsync() {
            return await _repo.CreateAsync(new Recipe());
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long id, RecipeUpdate recipe) {
            var entity = await _repo.GetAsync(id);
            _repo.Update(entity);
            _mapper.Map(recipe, entity);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long id) {
            await _repo.DeleteAsync(id);
        }
    }
}