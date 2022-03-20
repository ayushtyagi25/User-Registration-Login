using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int OperatorId { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public int PendingOrders { get; set; }
        public Decimal Outstanding { get; set; }
        public Decimal Overdue { get; set; }
        public Decimal Savings { get; set; }
        public Decimal CmSaving { get; set; }
        public int PendingCashEntry { get; set; }
        public String PendingCashEntryAmount { get; set; }
        public int WalletId { get; set; }

    }
}
