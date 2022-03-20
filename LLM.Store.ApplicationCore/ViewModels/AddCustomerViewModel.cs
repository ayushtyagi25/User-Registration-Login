using System;
using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int OperatorId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " Name must be between 1 and 50 characters", MinimumLength = 1)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int PendingOrders { get; set; }
        public Decimal Outstanding { get; set; }
        public Decimal Overdue { get; set; }
        public Decimal Savings { get; set; }
        public Decimal CmSaving { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int PendingCashEntry { get; set; }
        public String PendingCashEntryAmount { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int WalletId { get; set; }
    }
}
