using System;
using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class PaymentViewModel
    {
        public int StoreId { get; set; }
      
        public int PaymentId { get; set; }
       
        public int StoreCustomerId { get; set; }
       
        public decimal Amount { get; set; }
      
        public int OrderId { get; set; }
        
        public string Status { get; set; }
        
        public string Mode { get; set; }
        
        public DateTime Date { get; set; }
       
        public DateTime CreatedOn { get; set; }
        
        public decimal Adjusted { get; set; }
       
        public decimal Balance { get; set; }
        
        public string ReferenceNo { get; set; }
        
        public string AppId { get; set; }
       
        public int OperatorId { get; set; }
       
        public string Remarks { get; set; }
        
    }
}

