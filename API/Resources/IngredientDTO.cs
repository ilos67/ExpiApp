using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Resources
{
    public class IngredientDTO
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }
        public decimal Quantity { get; set; }
    }
}