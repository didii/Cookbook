using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Services {
    internal class FoodClientService : IFoodClientService {
        private readonly IApiHttpService _http;

        public FoodClientService(IApiHttpService http) {
            _http = http;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<FoodDto>> GetAll() {
            return await _http.GetAsync<IEnumerable<FoodDto>>($"api/food");
        }
    }
}