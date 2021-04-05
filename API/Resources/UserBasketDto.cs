using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Resources
{
    public class UserBasketDto
    {
         [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }    }
}