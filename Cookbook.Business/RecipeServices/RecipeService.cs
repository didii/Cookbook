using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cookbook.Db.Repositories;
using Cookbook.Domain;
using Cookbook.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Cookbook.Business.RecipeServices {
    internal class RecipeService : IRecipeService {
        private readonly IRecipeRepository _repo;
        private readonly ITagRepository _tagRepository;
        private readonly IAppliedTagRepository _appliedTagRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository repo, ITagRepository tagRepository, IAppliedTagRepository appliedTagRepository, IMapper mapper) {
            _repo = repo;
            _tagRepository = tagRepository;
            _appliedTagRepository = appliedTagRepository;
            _mapper = mapper;
        }
        /// <inheritdoc />
        public async Task<RecipeDto> GetAsync(long id) {
            var entity = await _repo.GetAsync(id);
            var model = _mapper.Map<RecipeDto>(entity);
            model.Tags = model.Tags.OrderBy(x => x.Name).ToList();
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
            await _repo.SaveAsync();
        }

        /// <inheritdoc />
        public async Task<RecipeDto> PatchAsync(int id, JsonPatchDocument<RecipeUpdate> patch) {
            var entity = await _repo.GetAsync(id);
            _repo.Update(entity);
            var entityPatch = _mapper.Map<JsonPatchDocument<Recipe>>(patch);
            entityPatch.ApplyTo(entity);
            await _repo.SaveAsync();
            var result = _mapper.Map<RecipeDto>(entity);
            return result;
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long id) {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TagDto>> GetTagsAsync(long id) {
            var entities = await _appliedTagRepository.GetByRecipeAsync(id);
            var dtos = _mapper.Map<IEnumerable<TagDto>>(entities);
            return dtos;
        }

        /// <inheritdoc />
        public async Task<TagDto> AddTagAsync(long id, TagEdit tag) {
            var tagEntity = await _tagRepository.GetByName(tag.Name);
            if (tagEntity == null) {
                tagEntity = _mapper.Map<Tag>(tag);
                await _tagRepository.CreateAsync(tagEntity);
            }
            var appliedTagEntity = new AppliedTag() { RecipeId = id, Tag = tagEntity };
            await _appliedTagRepository.CreateAsync(appliedTagEntity);
            await _repo.SaveAsync();
            var dto = _mapper.Map<TagDto>(appliedTagEntity);
            return dto;
        }

        /// <inheritdoc />
        public async Task RemoveTagAsync(long id, long tagId) {
            await _appliedTagRepository.DeleteAsync(id, tagId);
            await _tagRepository.UpdateAsync(tagId);
            await _repo.SaveAsync();
        }
    }
}