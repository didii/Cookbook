using System;

namespace Cookbook.Domain {
    public class FoodImage : IEntityImage<Food> {
        /// <inheritdoc />
        public long Id { get; set; }

        public long FoodId { get; set; }

        public virtual Food Food { get; set; }

        public long ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int Order { get; set; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedOn { get; set; }

        /// <inheritdoc />
        long IEntityImage<Food>.EntityId {
            get => FoodId;
            set => FoodId = value;
        }

        /// <inheritdoc />
        Food IEntityImage<Food>.Entity {
            get => Food;
            set => Food = value;
        }
    }
}