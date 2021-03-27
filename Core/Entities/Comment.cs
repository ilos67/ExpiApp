using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Identity;

namespace Core.Entities
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        [Required]
        public string Content { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}