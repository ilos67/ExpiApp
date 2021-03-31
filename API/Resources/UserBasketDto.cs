using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Resources
{
    public class UserBasketDto
    {
         [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
        public int? MealCategoryId { get; set; }
        public string ClientSecret { get; set; }
    }
}