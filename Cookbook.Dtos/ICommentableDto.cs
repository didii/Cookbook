using System.Collections.Generic;

namespace Cookbook.Dtos {
    public interface ICommentableDto {
        IEnumerable<CommentDto> Comments { get; set; }
    }
}