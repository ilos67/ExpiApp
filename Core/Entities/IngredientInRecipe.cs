using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("IngredientsInRecipes")]
    public class IngredientInRecipe : BaseEntity
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public string Quantity { get; set; }
    }
}