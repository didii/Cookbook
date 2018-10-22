using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cookbook.Db.Repositories;
using Cookbook.Domain;
using Cookbook.Dtos;

namespace Cookbook.Business {
    internal class FoodService : IFoodService {
        private readonly IFoodRepository _repo;
        private readonly IMapper _mapper;

        public FoodService(IFoodRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<FoodDto>> GetAllAsync() {
            var entities = await _repo.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<FoodDto>>(entities);
            return dtos;
        }

        /// <inheritdoc />
        public async Task<FoodDto> GetAsync(int id) {
            var entity = await _repo.GetAsync(id);
            var dto = _mapper.Map<FoodDto>(entity);
            return dto;
        }

        /// <inheritdoc />
        public async Task CreateAsync(FoodCreate food) {
            var entity = _mapper.Map<Food>(food);
            await _repo.AddAsync(entity);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(int id, FoodUpdate food) {
            var entity = _mapper.Map<Food>(food);
            entity.Id = id;
            await _repo.UpdateAsync(entity);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id) {
            await _repo.DeleteAsync(id);
        }
    }
}