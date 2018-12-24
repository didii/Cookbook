using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Web.Client.Components.SelectComponent {
    public class SelectChangedArgs<T> {
        public SelectedChangedType Type { get; set; }
        public int SelectedIndex { get; set; }
        public T SelectedItem { get; set; }
        public string Value { get; set; }
    }

    public enum SelectedChangedType {
        FromCollection,
        Other
    }

    public class SelectValue<T> {
        public virtual string Value { get; set; }
        public virtual string Display { get; set; }
        public virtual T ObjectValue { get; set; }
    }
}
