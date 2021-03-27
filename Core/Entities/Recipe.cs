using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Identity;

namespace Core.Entities
{
    [Table("Recipes")]
    public class Recipe : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Display(Name = "Preparation Time")]
        public string PreparationTime { get; set; }

        [EnumDataType(typeof(DifficultyLevel))]
        public DifficultyLevel DifficultyLevel { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        public MealCategory MealCategory { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public RecipePicture Picture { get; set; }

        public IEnumerable<IngredientInRecipe> Ingredients { get; set; }

        public IEnumerable<FavouriteRecipe> FavouriteRecipes { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }

    public enum DifficultyLevel
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }
}