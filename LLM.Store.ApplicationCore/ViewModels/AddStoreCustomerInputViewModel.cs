using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.ViewModel
{
    public class AddStoreCustomerInputViewModel
    {
        public int StoreId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " Name must be between 1 and 50 characters", MinimumLength = 1)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Personal Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        public string ContactNo { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(10, ErrorMessage = " Name must be between 1 and 50 characters", MinimumLength = 1)]
        public string FlatNo { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(10, ErrorMessage = " Name must be between 1 and 50 characters", MinimumLength = 1)]
        public string Block { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int LocationId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int NewCustomer { get; set; }

        public int CreditAllowed { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int CreditDays { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int CreatedBy { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int ModifiedBy { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int PendingOrders { get; set; }
        public decimal Outstanding { get; set; }
        public decimal Overdue { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int PendingCashEntry { get; set; }
        public decimal PendingCashEntryAmount { get; set; }

    }
}
