using System.Collections.Generic;
using System.Threading.Tasks;
using API.Resources;
using Core.Interface;

namespace API.Services
{
    public interface IIngredientService
    {
        //  Result<List<IngredientDTO>> GetItems();
         Result<List<IngredientDTO>> GetIngredientAsync();
    }
}