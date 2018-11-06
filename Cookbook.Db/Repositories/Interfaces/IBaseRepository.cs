using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface IBaseRepository<T> : IDisposable where T : class {
        Task SaveAsync();
    }
}