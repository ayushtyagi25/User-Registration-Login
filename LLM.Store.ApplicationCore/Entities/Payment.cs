using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Entities
{
   public class Payment
    {
        public int PaymentId { get; set; }
        public int StoreId { get; set; }
        public int StoreCustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; }
        public decimal Adjusted { get; set; }
        public object Balance { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string AppId { get; set; }
        public int OperatorId { get; set; }
        public string Remarks { get; set; }
       
    }
}
