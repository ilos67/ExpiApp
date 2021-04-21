using Core.Entities.RecipeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RecipeItemConfiguration : IEntityTypeConfiguration<RecipeItem>
    {
        public void Configure(EntityTypeBuilder<RecipeItem> builder)
        {
            builder.OwnsOne(i => i.ItemAdded, io => {io.WithOwner();});

            builder.Property(i => i.Price)
                .HasColumnType("decimal(18,2)");
            builder.Property(i => i.Quantity)
                .HasColumnType("decimal(18,2)");
        }
    }
}