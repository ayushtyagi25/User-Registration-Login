using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.ViewModels
{
   public class ListCustomerPaginationViewModel
    {
        public int CustomerId { get; set; }
        public int OperatorId { get; set; }
        public string Name { get; set; }
    }
}
