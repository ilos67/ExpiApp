using System.ComponentModel.DataAnnotations;

namespace API.Resources.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}