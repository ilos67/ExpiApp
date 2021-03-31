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

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(RecipeDTO recipeDTO)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var recipe = await _recipeService.CreateOrderAsync(email, recipeDTO.MealCategoryId, recipeDTO.BasketId);

            if(recipe == null) return BadRequest(new ApiResponse(400, "Problem creating recipe"));

            return Ok(recipe);
        }

        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RecipeDTO>>> GetRecipesForUser()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var recipes = await _recipeService.GetRecipesForUserAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<Recipe>, IReadOnlyList<RecipeToReturnDTO>>(recipes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeToReturnDTO>> GetRecipeByIdForUser(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var recipe = await _recipeService.GetRecipeByIdAsync(id,email);

            if (recipe == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Recipe, RecipeToReturnDTO>(recipe);
        }

        [HttpGet("mealCategories")]
        public async Task<ActionResult<IReadOnlyList<MealCategory>>> GetMealCategories()
        {
            return Ok(await _recipeService.GetMealCategoryAsync());
        }
    }
}