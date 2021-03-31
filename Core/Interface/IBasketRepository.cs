using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IBasketRepository
    {
         Task<UserBasket> GetBasketAsync(string basketId);
         Task<UserBasket> UpdateBasketAsync(UserBasket basket);
         Task<bool> DeleteBasketAsync(string basketId);
    }
}