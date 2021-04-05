using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("IngredientsInRecipes")]
    public class IngredientInRecipe
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public Product Product {get; set; }
        public int ProductId { get; set; }

        public decimal Quantity { get; set; }
    }
}