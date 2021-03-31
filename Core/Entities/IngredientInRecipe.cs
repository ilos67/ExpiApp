using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("IngredientsInRecipes")]
    public class IngredientInRecipe : BaseEntity
    {
        public IngredientInRecipe()
        {
        }

        public IngredientInRecipe(IngredientItemOrdered ıtemInRecipe, int quantity)
        {
            ItemInRecipe = ıtemInRecipe;
            Quantity = quantity;
        }

        public IngredientItemOrdered ItemInRecipe { get; set; }
        public int Quantity { get; set; }
    }
}