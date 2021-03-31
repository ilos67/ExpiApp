namespace Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public string IngredientName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}