using Core.Entities;

namespace Core.Specification
{
    public class IngredientWithCategorySpecification 
    {
    //     public IngredientWithCategorySpecification(IngredientSpecParams ingredientParams) : 
    //     base(x =>
    //     (string.IsNullOrEmpty(ingredientParams.Search) || x.Name.ToLower().Contains(ingredientParams.Search)) &&
    //     (!ingredientParams.CategoryId.HasValue)
    //     )
    //     {
    //         // AddInclude(x => x.IngredientCategory);
    //         AddOrderBy(x => x.Name);
    //        ApplyPaging (ingredientParams.PageSize * (ingredientParams.PageIndex - 1)      , ingredientParams.PageSize);

    //         if (!string.IsNullOrEmpty(ingredientParams.Sort))
    //         {
    //             switch (ingredientParams.Sort)
    //             {
    //                 case "priceAsc":
    //                     AddOrderBy(p => p.Price);
    //                     break;
    //                 case "priceDesc":
    //                     AddOrderByDescending(p => p.Price);
    //                     break;
    //                 default:
    //                     AddOrderBy(n => n.Name);
    //                     break;
    //             }
    //         }
    //     }

        // public IngredientWithCategorySpecification(int id) : base(x => x.Id == id)
        // {
        //     // AddInclude(x => x.IngredientCategory);
        // }
    }
}