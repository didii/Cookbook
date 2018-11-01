using System.Threading.Tasks;
using AutoMapper;
using Cookbook.Db.Repositories;
using Cookbook.Domain;
using Cookbook.Dtos;

namespace Cookbook.Business.RecipeServices {
    internal class TagService : ITagService {
        private readonly ITagRepository _repo;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }
        /// <inheritdoc />
        public async Task<long> CreateAsync(TagEdit tag) {
            var entity = _mapper.Map<Tag>(tag);
            var id = await _repo.CreateAsync(entity);
            await _repo.SaveAsync();
            return id;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long id, TagEdit tag) {
            var entity = await _repo.GetAsync(id);
            _repo.Update(entity);
            _mapper.Map(tag, entity);
            await _repo.SaveAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long id) {
            await _repo.DeleteAsync(id);
        }
    }
}