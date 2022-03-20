using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class RequestViewModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public int StoreTypeId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int StoreClassId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int OperatorId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " Name must be between 1 and 50 characters", MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = " Description must be between 0 and 500 characters", MinimumLength = 0)]
        public string Description { get; set; }
        [StringLength(255, ErrorMessage = " ImagePath must be between 0 and 255 characters", MinimumLength = 0)]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " ContactName must be between 1 and 50 characters", MinimumLength = 1)]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(20, ErrorMessage = " ContactNo must be between 1 and 20 characters", MinimumLength = 1)]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " AddressLine1 must be between 1 and 50 characters", MinimumLength = 1)]
        public string AddressLine1 { get; set; }
        [StringLength(50, ErrorMessage = " AddressLine2 must be between 0 and 50 characters", MinimumLength = 0)]
        public string AddressLine2 { get; set; }
        [StringLength(50, ErrorMessage = " AddressLine3 must be between 0 and 50 characters", MinimumLength = 0)]
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " City must be between 1 and 50 characters", MinimumLength = 1)]
        public string City { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " State must be between 1 and 50 characters", MinimumLength = 1)]
        public string State { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " Country must be between 1 and 50 characters", MinimumLength = 1)]
        public string Country { get; set; }
        [StringLength(10, ErrorMessage = " PostalCode must be between 0 and 10 characters", MinimumLength = 0)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public int IsActive { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public decimal CustOutstanding { get; set; }
        public decimal OpOutstanding { get; set; }
        public int TotalOrders { get; set; }
        public int CmOrders { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public decimal CmOrderAmount { get; set; }
        public int PendingOrders { get; set; }
        public decimal TotalRewards { get; set; }
        public decimal CmRewards { get; set; }
        public int TotalCash { get; set; }
        public int CmCash { get; set; }
        public decimal TotalCashAmount { get; set; }
        public decimal CmCashAmount { get; set; }
        public int PendingCashEntry { get; set; }
        public decimal PendingCashEntryAmount { get; set; }
        public int CmCallCount { get; set; }
        public int CmMissedCallCount { get; set; }
        public int MissedCalls { get; set; }
        public int TotalCallCount { get; set; }
        [StringLength(20, ErrorMessage = " VirtualNumber must be between 0 and 20 characters", MinimumLength = 0)]
        public string VirtualNumber { get; set; }

    }
}
