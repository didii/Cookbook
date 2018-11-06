using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Helpers {
    public static class IListExtensions {
        public static void ReplaceWithId<T>(this IList<T> source, long origId, T replacement) where T : IIdProperty {
            for (int i = 0; i < source.Count; i++) {
                if (source[i].Id != origId)
                    continue;
                source[i] = replacement;
                break;
            }
        }
    }
}
