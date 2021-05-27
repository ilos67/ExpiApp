using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Resources
{
    public class UserBasketDto
    {
         
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } 
    }
}