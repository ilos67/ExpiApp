using System;
using System.Linq;
using System.Reflection;
using Core.Entities;
using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Photo> Photos { get; set; }

         public DbSet<MealCategory> Categories { get; set; }
        public DbSet<IngredientCategory> IngredientCategory { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        // public DbSet<IngredientInRecipe> IngredientsInRecipes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipePicture> RecipePictures { get; set; }
        // public DbSet<FavouriteRecipe> FavouriteRecipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<FavouriteRecipe>().HasKey(fr => new { fr.AccountId, fr.RecipeId });

            // modelBuilder.Entity<FavouriteRecipe>()
            //     .HasOne<Account>(fr => fr.Account)
            //     .WithMany(u => u.FavouriteRecipes)
            //     .HasForeignKey(fr => fr.AccountId);


            // modelBuilder.Entity<FavouriteRecipe>()
            //     .HasOne<Recipe>(fr => fr.Recipe)
            //     .WithMany(r => r.FavouriteRecipes)
            //     .HasForeignKey(fr => fr.RecipeId);


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           //Fiyatın decimal olmasın ve SQLİTE'ın bunu desteklememesi yüzünden aşağıdaki ekleme yapılır
            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                    var dateTimeProperties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                     foreach (var property in dateTimeProperties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }


    }
}