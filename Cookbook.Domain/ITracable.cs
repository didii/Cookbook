using System;

namespace Cookbook.Domain {
    public interface ITracable {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}