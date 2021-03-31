using System.Collections.Generic;
using System.Threading.Tasks;
using API.Resources;
using Core.Entities;
using Core.Interface;

namespace API.Services
{
    public class IngredientService 
    {
        private readonly IUnitOfWork _unitOfWork;
        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // public Result<List<IngredientDTO>> GetIngredientAsync()
        // {
        //     List<IngredientDTO> items = new List<IngredientDTO>();
        //     var dataValue = _unitOfWork.Repository<IngredientDTO>().ListAllAsync();
        //     if (dataValue != null)
        //     {
        //         foreach (var item in dataValue)
        //         {
        //             items.Add(new IngredientDTO()
        //             {
        //                 ItemId = item.ItemId,
        //                 Name = item.Name,
        //                 Price = item.Price
        //             });
        //         }
        //         return new Result<List<IngredientDTO>>(true, ResultConstant.RecordFound, items);
        //     }
        //     return new Result<List<IngredientDTO>>(false, ResultConstant.RecordNotFound);
        // }
    }
}