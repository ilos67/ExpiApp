using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class RecipeWithItemsAndOrderingSpecification : BaseSpecification<Recipe>
    {

         public RecipeWithItemsAndOrderingSpecification(string email) : base(o => o.SourceEmail == email)
        {
            AddInclude(o => o.Ingredients);
            AddInclude(o => o.MealCategory);
            AddOrderByDescending(o => o.CreatedAt);
        }

        public RecipeWithItemsAndOrderingSpecification(int id, string email) 
            : base(o => o.Id == id && o.SourceEmail == email)
        {
            AddInclude(o => o.Ingredients);
            AddInclude(o => o.MealCategory);
        }
        
    }
}