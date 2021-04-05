using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Infrastructure.Data;

namespace API.Services
{
    public class RecipeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly StoreContext _context;

        public RecipeService(IUnitOfWork unitOfWork, StoreContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // public void AddIngredientsToRecipe(IEnumerable<IngredientInRecipe> ingredients, int productId)
        // {
        //     foreach (var ingredient in ingredients)
        //     {
        //         var newIngredient = new IngredientInRecipe()
        //         {
        //             IngredientId = ingredient.IngredientId,
        //             Quantity = ingredient.Quantity,
        //             ProductId = productId
        //         };

        //         _unitOfWork.Repository<IngredientInRecipe>().Add(newIngredient);
        //     }

        //     _unitOfWork.Complete();
        // }

        // public void CreateOrUpdateRecipe(Product product)
        // {
        //     if (product.Id == 0)
        //     {
        //         _unitOfWork.Repository<Product>().Add(product);
        //     }
        //     else
        //     {
        //         _unitOfWork.Repository<Product>().Update(product);

        //         var currentIngredients = _context.IngredientsInRecipes.Where(i => i.ProductId == product.Id);

        //         foreach (var ingredient in currentIngredients)
        //         {
        //             _unitOfWork.Repository<IngredientInRecipe>().Delete(ingredient);
        //         }
        //     }

        //     _unitOfWork.Complete();
        // }

        // public async Task<Product> GetRecipe(int id)
        // {
        //     // var recipe = Context.Recipes
        //     //     .Include(r => r.Category).Include(r => r.User)
        //     //     .Include(r => r.Comments)
        //     //     .Include(r => r.User)
        //     //     .Include(r => r.Comments).ThenInclude(r => r.User)
        //     //     .Include(r => r.Ingredients).ThenInclude(r => r.Ingredient)
        //     //     .FirstOrDefault(r => r.Id == id);

        //     // return recipe;
        //     var spec = new ProductsWithTypesAndBrandsSpecification(id);
        //     return await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);
        // }


        /*  Önceki Deneme
        
        public async Task<IReadOnlyList<Recipe>> GetRecipeAsync()
        {
            return await _unitOfWork.Repository<Recipe>().ListAllAsync();
        }


        // public async Task<IReadOnlyList<MealCategory>> GetMealCategoryAsync()
        // {
        //     return await _unitOfWork.Repository<MealCategory>().ListAllAsync();
        // }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            var spec = new RecipeWithItemsAndOrderingSpecification(id);
            return await _unitOfWork.Repository<Recipe>().GetEntityWithSpec(spec);
        }

        // public async Task<Recipe> CreateOrderAsync(string sourceEmail, int mealCategoryId, string basketId)
        // {
        //     var basket = await _basketRepository.GetBasketAsync(basketId);

        //     var items = new List<RecipeItems>();
        //     foreach (var item in basket.Items)
        //     {
        //         var ingredientItem = await _unitOfWork.Repository<Ingredient>().GetByIdAsync(item.Id);
        //         var itemIngredient = new IngredientItemOrdered(ingredientItem.Id, ingredientItem.Name);
        //         var recipeItem = new RecipeItems(itemIngredient, item.Quantity);
        //         items.Add(recipeItem);
        //     }

        //     var mealCategory = await _unitOfWork.Repository<MealCategory>().GetByIdAsync(mealCategoryId);

        //     //   var spec = new RecipeByPaymentIntentIdSpecification(basket.PaymentIntentId);
        //     // var existingOrder = await _unitOfWork.Repository<Recipe>().GetEntityWithSpec(spec);

        //     //  if (existingOrder != null)
        //     // {
        //     //     _unitOfWork.Repository<Recipe>().Delete(existingOrder);
        //     //     // await _paymentService.CreateOrUpdatePaymentIntent(basket.Id);
        //     // }

        //     var recipe = new Recipe (items,mealCategory,sourceEmail);
        //     _unitOfWork.Repository<Recipe>().Add(recipe);

        //       // save to db
        //     var result = await _unitOfWork.Complete();

        //     if (result <= 0) return null;

        //     // return order
        //     return recipe;
        // }

        // public async Task<IReadOnlyList<Recipe>> GetRecipesForUserAsync(string sourceEmail)
        // {
        //     var spec = new RecipeWithItemsAndOrderingSpecification(sourceEmail);
        //     return await _unitOfWork.Repository<Recipe>().ListAsync(spec);
        // }

        */
    }
}