using System;
using System.Collections.Generic;

namespace Cookbook.Dtos {
    public class IngredientCommon {
        public long FoodId { get; set; }

        public virtual FoodDto Food { get; set; }

        public long QuantityId { get; set; }

        public virtual QuantityDto Quantity { get; set; }

        public double? QuantityValue { get; set; }
    }

    public class IngredientDto : IngredientCommon, IDtoBase, IIdProperty, ITracableDto, ITrackableDto, ICommentableDto {
        /// <inheritdoc />
        public long Id { get; set; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedOn { get; set; }

        /// <inheritdoc />
        public virtual UserDto CreatedBy { get; set; }

        /// <inheritdoc />
        public virtual UserDto UpdatedBy { get; set; }

        public virtual IEnumerable<CommentDto> Comments { get; set; }
    }

    public class IngredientCreate : IngredientCommon, IDtoCreateBase { }

    public class IngredientUpdate : IngredientCommon, IDtoUpdateBase { }
}