using System;

namespace API.Resources
{
    public class RecipeDTO
    {
        public string BasketId { get; set; }
        public int MealCategoryId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}