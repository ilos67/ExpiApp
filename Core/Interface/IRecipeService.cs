using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IRecipeService
    {
        Task<Product> CreateOrderAsync(int id,string basketId);
    }
}