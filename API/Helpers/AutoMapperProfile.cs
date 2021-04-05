using System.Linq;
using API.Resources;
using API.Resources.Accounts;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();

            CreateMap<CreateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

        
             CreateMap<UserBasketDto, UserBasket>();
            CreateMap<BasketItemDto, BasketItem>();


            CreateMap<Photo, PhotoToReturnDto>()
                .ForMember(d => d.PictureUrl, 
                    o => o.MapFrom<PhotoUrlResolver>());

            CreateMap<ProductCreateDto, Product>();

            CreateMap<Product, ProductToReturnDto>()
             .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                // .ForMember(d => d.Ingredients, o => o.MapFrom(s => s.Ingredients.Select(vf => new KeyValuePairResource {Id = vf.Ingredient.Id, Name = vf.Ingredient.Name})))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());  

            CreateMap<IngredientInRecipe, RecipeToReturnDTO>()
            .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity))
            .ForMember(d => d.Id, o => o.MapFrom(s => s.IngredientId))
            .ForMember(d => d.IngredientName, o => o.MapFrom(s => s.Ingredient.Name))
            ;
        }
    }
}