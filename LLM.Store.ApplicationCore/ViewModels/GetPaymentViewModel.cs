using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class GetPaymentViewModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public int StoreId { get; set; }
    }
}
