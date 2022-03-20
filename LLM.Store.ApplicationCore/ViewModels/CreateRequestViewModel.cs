using System;
using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class CreateRequestViewModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " UserName must be between 1 and 50 characters", MinimumLength = 1)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " UserPassword  must be between 1 and 50 characters", MinimumLength = 1)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(1, char.MaxValue, ErrorMessage = "Please enter valid Gender")]
        public char Gender { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(30, ErrorMessage = " MobileNumber  must be between 1 and 30 characters", MinimumLength = 1)]
        public string MobileNumber { get; set; } 
    }
}
