using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Web.Client.Components.EditableComponent {
    public class EditableModel<T> {
        public T OriginalValue { get; set; }
        public T CurrentValue { get; set; }
    }
}
