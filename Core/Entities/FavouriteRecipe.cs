using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Identity;

namespace Core.Entities
{
     [Table("FavouriteRecipes")]
    public class FavouriteRecipe
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}