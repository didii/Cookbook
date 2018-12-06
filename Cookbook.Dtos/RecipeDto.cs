using System;
using System.Collections.Generic;

namespace Cookbook.Dtos {
    public class RecipeDto : IDtoBase {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Servings { get; set; }
        public TimeSpan Duration { get; set; }
        public float EstimatedPrice { get; set; }
        public int Difficulty { get; set; }
        public IList<IngredientDto> Ingredients { get; set; }
        public IEnumerable<RecipeHowToDto> HowTo { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IList<TagDto> Tags { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public UserDto CreatedBy { get; set; }
        public UserDto UpdatedBy { get; set; }
    }

    public class RecipeUpdate : IDtoUpdateBase {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Servings { get; set; }
        public TimeSpan? Duration { get; set; }
        public float? EstimatedPrice { get; set; }
        public int Difficulty { get; set; }
    }
}