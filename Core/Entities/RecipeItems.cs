namespace Core.Entities
{
    public class RecipeItems : BaseEntity
    {
        public RecipeItems()
        {
        }

        public RecipeItems(IngredientItemOrdered ıtemReciped, decimal quantity)
        {
            ItemReciped = ıtemReciped;
            Quantity = quantity;
        }

        public IngredientItemOrdered ItemReciped { get; set; }
        public decimal Quantity { get; set; }
    }
}