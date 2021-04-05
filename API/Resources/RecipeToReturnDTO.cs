using System;
using System.Collections.Generic;

namespace API.Resources
{
    public class RecipeToReturnDTO
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
       
    }
}