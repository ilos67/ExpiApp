namespace Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}