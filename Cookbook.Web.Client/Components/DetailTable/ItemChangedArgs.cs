using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Web.Client.Components.DetailTable {
    public struct ItemChangedArgs<T> {
        public T Item { get; set; }
        public ItemChangedType Type { get; set; }
        public int? Index { get; set; }
    }

    public enum ItemChangedType {
        Added,
        Changed,
        Deleted
    }
}
