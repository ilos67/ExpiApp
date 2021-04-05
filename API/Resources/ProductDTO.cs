using System.Collections.Generic;

namespace API.Resources
{
    public class ProductDTO
    {
        public RecipeDTO RecipeDTO { get; set; }
        public List<RecipeToReturnDTO> RecipeToReturnDtos { get; set; }
    }
}