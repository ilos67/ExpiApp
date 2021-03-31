namespace Core.Entities
{
    public class IngredientItemOrdered
    {
        public IngredientItemOrdered()
        {
        }

        public IngredientItemOrdered(int ingredientItemId, string ingredientName)
        {
            IngredientItemId = ingredientItemId;
            IngredientName = ingredientName;
        }

        public int IngredientItemId { get; set; }
        public string IngredientName { get; set; }
    }
}