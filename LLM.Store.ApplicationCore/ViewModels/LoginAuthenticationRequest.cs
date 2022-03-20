using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class LoginAuthenticationRequest
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " UserName must be between 1 and 50 characters", MinimumLength = 1)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " UserPassword must be between 1 and 50 characters", MinimumLength = 1)]
        public string UserPassword { get; set; }
    }
}
