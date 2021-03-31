using System.Collections.Generic;

namespace Core.Entities
{
    public class UserBasket
    {
        public UserBasket()
        {
        }

        public UserBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int? MealCategoryId { get; set; }
        public string ClientSecret { get; set; }
    }
}