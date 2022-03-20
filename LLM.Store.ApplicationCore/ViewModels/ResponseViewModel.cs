using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class ResponseViewModel
    {
        public int StoreId { get; set; }
        public int StoreTypeId { get; set; }
        public int StoreClassId { get; set; }
        public int OperatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int IsActive { get; set; }
        //public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        //public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public decimal CustOutstanding { get; set; }
        public decimal OpOutstanding { get; set; }
        public int TotalOrders { get; set; }
        public int CmOrders { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public decimal CmOrderAmount { get; set; }
        public int PendingOrders { get; set; }
        public decimal TotalRewards { get; set; }
        public decimal CmRewards { get; set; }
        public int TotalCash { get; set; }
        public int CmCash { get; set; }
        public decimal TotalCashAmount { get; set; }
        public decimal CmCashAmount { get; set; }
        public int PendingCashEntry { get; set; }
        public decimal PendingCashEntryAmount { get; set; }
        public int CmCallCount { get; set; }
        public int CmMissedCallCount { get; set; }
        public int MissedCalls { get; set; }
        public int TotalCallCount { get; set; }
        public string VirtualNumber { get; set; }

    }
}
