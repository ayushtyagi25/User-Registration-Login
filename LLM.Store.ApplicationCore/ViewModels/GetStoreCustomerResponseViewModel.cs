namespace LLM.Store.ApplicationCore.ViewModel
{
    public class GetStoreCustomerResponseViewModel
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

    }
}
