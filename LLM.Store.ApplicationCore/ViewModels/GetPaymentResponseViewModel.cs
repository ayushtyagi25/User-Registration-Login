namespace LLM.Store.ApplicationCore.ViewModels
{
    public class GetPaymentResponseViewModel
    {
        public int PaymentId { get; set; }
        public int StoreId { get; set; }
        public int StoreCustomerId { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
       
    }
}
