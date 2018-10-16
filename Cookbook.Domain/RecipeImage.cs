using System;

namespace Cookbook.Domain {
    public class RecipeImage : IEntityImage<Recipe> {
        /// <inheritdoc />
        public long Id { get; set; }

        /// <inheritdoc />
        public long ImageId { get; set; }

        /// <inheritdoc />
        public virtual Image Image { get; set; }

        public long RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        /// <inheritdoc />
        long IEntityImage<Recipe>.EntityId {
            get => RecipeId;
            set => RecipeId = value;
        }

        /// <inheritdoc />
        Recipe IEntityImage<Recipe>.Entity {
            get => Recipe;
            set => Recipe = value;
        }

        /// <inheritdoc />
        public int Order { get; set; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedOn { get; set; }
    }
}