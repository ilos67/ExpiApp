using System;
using System.Collections.Generic;

namespace API.Resources
{
    public class RecipeToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SourceEmail { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string MealCategory { get; set; }
        public IReadOnlyList<IngredientDTO> IngredientInRecipeItems { get; set; }
      
    }
}