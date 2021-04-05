using System.Collections.Generic;
using System.Threading.Tasks;
using API.Errors;
using API.Extensions;
using API.Resources;
using API.Services;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RecipesController : BaseApiController
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<MealCategory> _mealRepo;
        public RecipesController(IRecipeService recipeService, IMapper mapper, IGenericRepository<MealCategory> mealRepo)
        {
            _mealRepo = mealRepo;
            _mapper = mapper;
            _recipeService = recipeService;

        }

        // [HttpGet]
        // public async Task<ActionResult<IReadOnlyList<RecipeDTO>>> GetOrdersForUser()
        // {
        //     // var email = HttpContext.User.RetrieveEmailFromPrincipal();

        //     var orders = await _recipeService.GetRecipeAsync();
        //      return Ok(_mapper.Map<IReadOnlyList<Recipe>, IReadOnlyList<RecipeDTO>>(orders));
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<RecipeDTO>> GetOrderByIdForUser(int id)
        // {
        //     // var email = HttpContext.User.RetrieveEmailFromPrincipal();

        //     var order = await _recipeService.GetRecipeByIdAsync(id);

        //     if (order == null) return NotFound(new ApiResponse(404));

        //     return _mapper.Map<Recipe, RecipeDTO>(order);
        // }


        // [HttpPost]
        // public async Task<ActionResult<Recipe>> CreateRecipe(RecipeDTO recipeDTO)
        // {
        //     var email = HttpContext.User.RetrieveEmailFromPrincipal();

        //     var recipe = await _recipeService.CreateOrderAsync(email, recipeDTO.MealCategoryId, recipeDTO.BasketId);

        //     if(recipe == null) return BadRequest(new ApiResponse(400, "Problem creating recipe"));

        //     return Ok(recipe);
        // }

        
        
    }
}