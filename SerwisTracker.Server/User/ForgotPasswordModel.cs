using System.ComponentModel.DataAnnotations;

namespace SerwisTracker.Server.User
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email wymagany")]
        public string? Email { get; set; }
    }
}
