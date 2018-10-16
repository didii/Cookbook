namespace Cookbook.Dtos {
    public class QuantityTypeDto : IDtoBase, IIdProperty {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class QuantityTypeCreate : IDtoCreateBase {
        public string Name { get; set; }
    }

    public class QuantityTypeUpdate : IDtoUpdateBase {
        public string Name { get; set; }
    }
}