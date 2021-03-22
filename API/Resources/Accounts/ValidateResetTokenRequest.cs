using System.ComponentModel.DataAnnotations;

namespace API.Resources.Accounts
{
    public class ValidateResetTokenRequest
    {
         [Required]
        public string Token { get; set; }
    }
}