using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Cookbook.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Cookbook.Web.Client.Services {
    class ChangeTracker<T> : IChangeTracker<T> where T : class {
        private T _value = null;

        /// <inheritdoc />
        public JsonPatchDocument<T> PatchDocument { get; private set; } = new JsonPatchDocument<T>();

        /// <inheritdoc />
        public void Set<TProp>(Expression<Func<T, TProp>> property, TProp newValue) {
            Guard();
            PatchDocument.Replace(property, newValue);
        }

        /// <inheritdoc />
        public void Set<TProp>(Expression<Func<T, IList<TProp>>> property, long id, TProp newValue) where TProp : IIdProperty {
            Guard();
            int idx = FindIndex(property.Compile()(_value), id);
            if (idx >= 0)
                PatchDocument.Replace(property, newValue, idx);
        }

        /// <inheritdoc />
        public void Add<TProp>(Expression<Func<T, IList<TProp>>> property, TProp value) {
            Guard();
            PatchDocument.Add(property, value);
        }

        /// <inheritdoc />
        public void Remove<TProp>(Expression<Func<T, IList<TProp>>> property, long id) where TProp : IIdProperty {
            Guard();
            var idx = FindIndex(property.Compile()(_value), id);
            if (idx >= 0)
                PatchDocument.Remove(property, idx);
        }

        /// <inheritdoc />
        public void Reset(T newValue = null) {
            _value = newValue;
            PatchDocument = new JsonPatchDocument<T>();
        }

        private void Guard() {
            if (_value == null)
                throw new InvalidOperationException("Must have called Reset with a value at least once before using operators");
        }

        private int FindIndex<TProp>(IEnumerable<TProp> iEnum, long id) where TProp : IIdProperty {
            int idx = 0;
            foreach (var item in iEnum) {
                if (item.Id == id)
                    return idx;
                idx++;
            }
            return -1;
        }
    }
}
