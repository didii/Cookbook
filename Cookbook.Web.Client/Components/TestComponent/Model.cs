using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Web.Client.Components.TestComponent {
    public class Model {
        public int Id { get;set; }
        public string Name { get; set; }
        public SubModel SubModel { get; set; }
    }

    public class SubModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubSubModel SubSubModel { get;set; }
    }

    public class SubSubModel {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
