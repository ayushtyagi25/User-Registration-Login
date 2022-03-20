using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class StoreListRequestViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }


    }
}
