namespace Core.Entities.RecipeAggregate
{
    public class RecipeItem : BaseEntity
    {
        public RecipeItem()
        {
        }

        public RecipeItem(IngredientItemAdded itemAdded, decimal price, decimal quantity)
        {
            ItemAdded = itemAdded;
            Price = price;
            Quantity = quantity;
        }

        public IngredientItemAdded ItemAdded { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}