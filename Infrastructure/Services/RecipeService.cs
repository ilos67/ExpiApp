using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.RecipeAggregate;
using Core.Interface;

namespace Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        public RecipeService(IBasketRepository basketRepo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _basketRepo = basketRepo;
        }

        public async Task<Product> CreateOrderAsync(int id, string basketId)
        {
             // get basket from the repo
            var basket = await _basketRepo.GetBasketAsync(basketId);

            // get items from the product repo
            var items = new List<RecipeItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Ingredient>().GetByIdAsync(item.Id);
                var itemOrdered = new IngredientItemAdded(productItem.Id, productItem.Name);
                var orderItem = new RecipeItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

             // create order
            var order = new Product(items);
            _unitOfWork.Repository<Product>().Add(order);

            // save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            // return order
            return order;
        }
    }
}