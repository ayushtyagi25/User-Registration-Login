using System;

namespace LLM.Store.ApplicationCore.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int OperatorId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int StoreCustomerId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public int ReferenceNo { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

    }
}
