using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Infrastructure.Data;

namespace API.Services
{
    public class RecipeService : IRecipeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;

        public RecipeService(IUnitOfWork unitOfWork, IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<MealCategory>> GetMealCategoryAsync()
        {
            return await _unitOfWork.Repository<MealCategory>().ListAllAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id, string sourceMail)
        {
            var spec = new RecipeWithItemsAndOrderingSpecification(id, sourceMail);
            return await _unitOfWork.Repository<Recipe>().GetEntityWithSpec(spec);
        }

        public async Task<Recipe> CreateOrderAsync(string sourceEmail, int mealCategoryId, string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);

            var items = new List<RecipeItems>();
            foreach (var item in basket.Items)
            {
                var ingredientItem = await _unitOfWork.Repository<Ingredient>().GetByIdAsync(item.Id);
                var itemIngredient = new IngredientItemOrdered(ingredientItem.Id, ingredientItem.Name);
                var recipeItem = new RecipeItems(itemIngredient, item.Quantity);
                items.Add(recipeItem);
            }

            var mealCategory = await _unitOfWork.Repository<MealCategory>().GetByIdAsync(mealCategoryId);

            //   var spec = new RecipeByPaymentIntentIdSpecification(basket.PaymentIntentId);
            // var existingOrder = await _unitOfWork.Repository<Recipe>().GetEntityWithSpec(spec);

            //  if (existingOrder != null)
            // {
            //     _unitOfWork.Repository<Recipe>().Delete(existingOrder);
            //     // await _paymentService.CreateOrUpdatePaymentIntent(basket.Id);
            // }

            var recipe = new Recipe (items,mealCategory,sourceEmail);
            _unitOfWork.Repository<Recipe>().Add(recipe);

              // save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            // return order
            return recipe;
        }

        public async Task<IReadOnlyList<Recipe>> GetRecipesForUserAsync(string sourceEmail)
        {
            var spec = new RecipeWithItemsAndOrderingSpecification(sourceEmail);
            return await _unitOfWork.Repository<Recipe>().ListAsync(spec);
        }
    }
}