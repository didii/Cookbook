using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Db.Contexts {
    public interface ISeeder {
        void Seed(IServiceScope scope, IConfiguration configuration);
    }
}