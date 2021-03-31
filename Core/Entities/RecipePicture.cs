using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("RecipePictures")]
    public class RecipePicture : FilesRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}