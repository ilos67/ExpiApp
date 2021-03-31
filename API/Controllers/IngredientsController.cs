using System.Collections.Generic;
using System.Threading.Tasks;
using API.Errors;
using API.Helpers;
using API.Resources;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IngredientsController : BaseApiController
    {
        private readonly IGenericRepository<Ingredient> _ingredientRepo;
        private readonly IMapper _mapper;
        public IngredientsController(IGenericRepository<Ingredient> ingredientRepo, IMapper mapper)
        {
            _mapper = mapper;
            _ingredientRepo = ingredientRepo;

        }

        // [HttpGet]
        // public async Task<ActionResult<Pagination<IngredientDTO>>> GetIngredients(
        //   [FromQuery] IngredientSpecParams ingredientParams)

        // {
        //     //  1-  var products = await _context.Products.ToListAsync(); // After Interfaces made
        //     //  2- var products = await _repo.GetProductsAsync();
        //     //  3-  var products = await _productsRepo.ListAllAsync();
        //     /*   4-
        //      var spec = new ProductsWithTypesAndBrandsSpecification();
        //      var products = await _productsRepo.ListAsync(spec);

        //      return Ok(products);
        //      */

        //     /*5-
        //      var spec = new ProductsWithTypesAndBrandsSpecification();
        //     // var products = await _productsRepo.ListAsync(spec);
        //     // return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        //     */

        // //     var spec = new IngredientWithCategorySpecification(ingredientParams);

        // //     var countSpec = new IngredientWithFiltersForCountSpecification(ingredientParams);

        // //     var totalItems = await _ingredientRepo.CountAsync(countSpec);

        // //     var ingredients = await _ingredientRepo.ListAsync(spec);

        // //     var data = _mapper.Map<IReadOnlyList<Ingredient>, IReadOnlyList<IngredientDTO>>(ingredients);

        // //     return Ok(new Pagination<IngredientDTO>(ingredientParams.PageIndex, ingredientParams.PageSize, totalItems, data));


        // // }

        // // [HttpGet("{id}")]
        // // [ProducesResponseType(StatusCodes.Status200OK)]
        // // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // // public async Task<ActionResult<IngredientDTO>> GetIngredient(int id)
        // // {
        // //     var spec = new IngredientWithCategorySpecification(id);

        // //     var ingredient = await _ingredientRepo.GetEntityWithSpec(spec);

        // //     if (ingredient == null) return NotFound(new ApiResponse(404));

        // //     return _mapper.Map<Ingredient, IngredientDTO>(ingredient);
        // // }

        
        // [HttpGet("ingredientCategory")]
        // public async Task<ActionResult<IReadOnlyList<IngredientCategory>>> GetIngredientCategory()
        // {
        //     return Ok(await _ingredientRepo.ListAllAsync());
        // }
    }
}