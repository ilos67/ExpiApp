using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class IngredientInRecipeConfiguration : IEntityTypeConfiguration<RecipeItems>
    {

        public void Configure(EntityTypeBuilder<RecipeItems> builder)
        {
            builder.OwnsOne(i => i.ItemReciped, io => {io.WithOwner();});
            builder.Property(i => i.Quantity)
                .HasColumnType("decimal(18,2)");
        }
    }
}