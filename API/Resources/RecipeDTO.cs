using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.Resources
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IngredientInRecipe> Ingredients { get; set; }
    }
}