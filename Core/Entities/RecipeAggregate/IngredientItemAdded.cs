namespace Core.Entities.RecipeAggregate
{
    public class IngredientItemAdded
    {
        public IngredientItemAdded()
        {
        }

        public IngredientItemAdded(int ingredientItemId, string ingredientName)
        {
            IngredientItemId = ingredientItemId;
            IngredientName = ingredientName;
        }

        public int IngredientItemId { get; set; }
        public string IngredientName { get; set; }
    }
}