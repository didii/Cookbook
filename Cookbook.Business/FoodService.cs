using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Business {
    internal class FoodService : IFoodService {
        /// <inheritdoc />
        public async Task<IEnumerable<FoodDto>> GetAll() {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<FoodDto> Get(int id) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task Create(FoodCreate food) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task Update(FoodUpdate food) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task Delete(int id) {
            throw new NotImplementedException();
        }
    }
}