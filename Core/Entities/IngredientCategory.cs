using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("IngredientCategories")]
    public class IngredientCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}