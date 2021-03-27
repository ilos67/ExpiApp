using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("RecipePictures")]
    public class RecipePicture : File
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}