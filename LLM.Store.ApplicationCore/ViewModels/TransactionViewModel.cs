using System;
using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class TransactionViewModel
    {
       
        public int TransactionId { get; set; }   
       
        public int StoreId { get; set; }
      
        [StringLength(50, ErrorMessage = " StoreName must be between 1 and 50 characters", MinimumLength = 1)]
        public string StoreName { get; set; }
        
        public int StoreCustomerId { get; set; }
        
        [StringLength(20, ErrorMessage = " ContactNo must be between 1 and 20 characters", MinimumLength = 1)]
        public string ContactNo { get; set; }
       
        public int ReferenceNo { get; set; }
        
        public decimal Amount { get; set; }
       
        public int OperatorId { get; set; }
        
        public int CustomerId { get; set; }
        
        [StringLength(50, ErrorMessage = " CustomerName must be between 1 and 50 characters", MinimumLength = 1)]
        public string CustomerName { get; set; } 
        public DateTime Date { get; set; }
       
        [StringLength(50, ErrorMessage = " Category must be between 1 and 50 characters", MinimumLength = 1)]
        public string Category { get; set; }
        public string Type { get; set; }
        
        [StringLength(20, ErrorMessage = " SubType must be between 1 and 20 characters", MinimumLength = 1)]
        public string SubType { get; set; }
        
        [StringLength(100, ErrorMessage = " Description must be between 1 and 100 characters", MinimumLength = 1)]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

    }
}
