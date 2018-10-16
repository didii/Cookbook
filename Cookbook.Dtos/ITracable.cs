using System;

namespace Cookbook.Dtos {
    public interface ITracable {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}