using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("MealCategories")]
    public class MealCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}