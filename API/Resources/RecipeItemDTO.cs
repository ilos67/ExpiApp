namespace API.Resources
{
    public class RecipeItemDTO
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}