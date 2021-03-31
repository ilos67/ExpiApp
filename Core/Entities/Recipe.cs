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
        public Recipe()
        {
        }

        public Recipe(IReadOnlyList<RecipeItems> ingredients, MealCategory mealCategory, string sourceEmail)
        {
            MealCategory = mealCategory;
            SourceEmail = sourceEmail;
            Ingredients = ingredients;
        }

        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }= DateTimeOffset.Now;
        public MealCategory MealCategory { get; set; }
        public string SourceEmail { get; set; }
        public IReadOnlyList<RecipeItems> Ingredients { get; set; }
       
    }

}