using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Resources
{
    public class IngredientDTO
    {
       [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string IngredientCategory { get; set; }
    }
}