using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.ViewModel
{
    public class AddStoreCustomerResponseViewModel
    {
        public int StoreCustomerId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }



    }
}
