using System.ComponentModel.DataAnnotations;

namespace API.Resources.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}