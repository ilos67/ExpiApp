using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Services
{
    public interface IRecipeService
    {
        Task<Product> GetRecipe(int id);
        void CreateOrUpdateRecipe(Product product);
        void AddIngredientsToRecipe(IEnumerable<IngredientInRecipe> ingredients, int productId);
    }
}