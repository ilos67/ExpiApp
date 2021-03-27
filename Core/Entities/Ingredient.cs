using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Ingredients")]
    public class Ingredient : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public int IngredientCategoryId { get; set; }
        public IngredientCategory IngredientCategory { get; set; }
    }
}