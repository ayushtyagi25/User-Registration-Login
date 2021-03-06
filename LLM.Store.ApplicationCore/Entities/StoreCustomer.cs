namespace LLM.Store.ApplicationCore.Entities
{
    public class StoreCustomer
    {
        public int StoreCustomerId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string FlatNo { get; set; }
        public string Block { get; set; }
        public int LocationId { get; set; }
        public int NewCustomer { get; set; }
        public int CreditAllowed { get; set; }
        public int CreditDays { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int PendingOrders { get; set; }
        public decimal Outstanding { get; set; }
        public decimal Overdue { get; set; }
        public int PendingCashEntry { get; set; }
        public decimal PendingCashEntryAmount { get; set; }

    }
}

