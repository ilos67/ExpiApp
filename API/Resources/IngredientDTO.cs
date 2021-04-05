using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Resources
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}