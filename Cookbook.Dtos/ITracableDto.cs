using System;

namespace Cookbook.Dtos {
    public interface ITracableDto {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}