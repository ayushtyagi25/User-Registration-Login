using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.ViewModels
{
   public class UpdatePaymentResponseViewModel
    {
        public int PaymentId { get; set; }
        public int StoreId { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
        public decimal Amount { get; set; }
    }
}
