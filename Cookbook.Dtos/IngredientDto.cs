using System;
using System.Collections.Generic;

namespace Cookbook.Dtos {
    public class IngredientDto : IDtoBase, IIdProperty, ITracableDto, ITrackableDto, ICommentableDto {
        /// <inheritdoc />
        public long Id { get; set; }

        public long FoodId { get; set; }

        public virtual FoodDto Food { get; set; }

        public long QuantityId { get; set; }

        public virtual QuantityDto Quantity { get; set; }

        public double? QuantityValue { get; set; }

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

    public class IngredientEdit : IDtoCreateBase, IDtoUpdateBase {
        public static IngredientEdit FromDto(IngredientDto dto) {
            if (dto == null)
                return null;
            return new IngredientEdit() {
                FoodId = dto.FoodId,
                QuantityId = dto.QuantityId,
                QuantityValue = dto.QuantityValue
            };
        }

        public long FoodId { get; set; }

        public long QuantityId { get; set; }

        public double? QuantityValue { get; set; }
    }
}