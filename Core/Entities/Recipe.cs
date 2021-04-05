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
      
        public string Name { get; set; }
        // public IReadOnlyList<IngredientInRecipe> RecipeItems { get; set; }
       
    }

}