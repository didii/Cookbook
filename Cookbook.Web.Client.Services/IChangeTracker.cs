using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Cookbook.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Cookbook.Web.Client.Services {
    public interface IChangeTracker<T> where T : class {
        JsonPatchDocument<T> PatchDocument { get; }
        void Set<TProp>(Expression<Func<T, TProp>> property, TProp newValue);
        void Set<TProp>(Expression<Func<T, IList<TProp>>> property, long id, TProp newValue) where TProp : IIdProperty;
        void Add<TProp>(Expression<Func<T, IList<TProp>>> property, TProp value);
        void Remove<TProp>(Expression<Func<T, IList<TProp>>> property, long id) where TProp : IIdProperty;
        void Reset(T newValue = null);
    }
}
