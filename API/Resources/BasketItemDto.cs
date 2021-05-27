using System.ComponentModel.DataAnnotations;

namespace API.Resources
{
    public class BasketItemDto
    {
        // [Required]
        public int Id { get; set; }

        // [Required]
        public string IngredientName { get; set; }

        // [Required]
        // [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public decimal Quantity { get; set; }

        
    }
}