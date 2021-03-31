using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Services
{
    public interface IRecipeService
    {
     
        Task<Recipe> CreateOrderAsync(string sourceEmail, int deliveryMethod, string basketId);
         Task<IReadOnlyList<Recipe>> GetRecipesForUserAsync(string sourceEmail);
         Task<Recipe> GetRecipeByIdAsync( int id, string sourceMail);
         Task<IReadOnlyList<MealCategory>> GetMealCategoryAsync();

    }
}