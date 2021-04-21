using System.Collections.Generic;
using System.Threading.Tasks;
using API.Errors;
using API.Helpers;
using API.Resources;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IngredientsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public IngredientsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<IngredientToReturnDto>>> GetIngredients(
          [FromQuery] IngredientSpecParams ingredientParams)

        {
           var spec = new IngredientSpecification(ingredientParams);

            var countSpec = new IngredientWithFiltersForCountSpecification(ingredientParams);

            var totalItems = await _unitOfWork.Repository<Ingredient>().CountAsync(countSpec);

            var ingredients = await _unitOfWork.Repository<Ingredient>().ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Ingredient>, IReadOnlyList<IngredientToReturnDto>>(ingredients);

            return Ok(new Pagination<IngredientToReturnDto>(ingredientParams.PageIndex, ingredientParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientToReturnDto>> GetIngredient(int id)
        {
           
            var spec = new IngredientSpecification(id);

            var ingredient = await _unitOfWork.Repository<Ingredient>().GetEntityWithSpec(spec);

            if (ingredient == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Ingredient, IngredientToReturnDto>(ingredient);


        }
        
    }
}