using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.Utils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LLM.Store.DAL
{
    public class PaymentData : IPaymentData
    {
        public async Task<Payment> AddPayment(Payment entity)
        {
            DbParam[] param = new DbParam[15];


            param[0] = new DbParam("p_StoreId", entity.StoreId, MySqlDbType.Int32);
            param[1] = new DbParam("p_StoreCustomerId", entity.StoreCustomerId, MySqlDbType.Int32);
            param[2] = new DbParam("p_Date", entity.Date, MySqlDbType.DateTime);
            param[3] = new DbParam("p_Status", entity.Status, MySqlDbType.VarChar);
            param[4] = new DbParam("p_Mode", entity.Mode, MySqlDbType.VarChar);
            param[5] = new DbParam("p_Amount", entity.Amount, MySqlDbType.Decimal);
            param[6] = new DbParam("p_OrderId", entity.OrderId, MySqlDbType.Int32);
            param[7] = new DbParam("p_Adjusted", entity.Adjusted, MySqlDbType.Decimal);
            param[8] = new DbParam("p_Balance", entity.Balance, MySqlDbType.Decimal);
            param[9] = new DbParam("p_ReferenceNo", entity.ReferenceNo, MySqlDbType.VarChar);
            param[10] = new DbParam("p_CreatedOn", entity.CreatedOn, MySqlDbType.DateTime);
            param[11] = new DbParam("p_CreatedBy", entity.CreatedBy, MySqlDbType.Int32);
            param[12] = new DbParam("p_AppId", entity.AppId, MySqlDbType.VarChar);
            param[13] = new DbParam("p_OperatorId", entity.OperatorId, MySqlDbType.Int32);
            param[14] = new DbParam("p_Remarks", entity.Remarks, MySqlDbType.VarChar);



            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorepayment_AddStorePayment", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Payment>()[0];
            }
            else
            {
                return null;
            }

        }
        public async Task<Payment> GetPayment(int StoreId)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_StoreId", StoreId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblpayment_GetPayment", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Payment>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<Payment> DeletePayment(Payment entity)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_PaymentId", entity.PaymentId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblpayment_DeletePayment", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Payment>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<Payment> UpdatePayment(Payment entity)
        {
            if (entity.Status.Contains("Phonepay"))
            {
                entity.Status = "Successful";
            }
            else
            {
                entity.Status = "Unsuccessful";
            }
            DbParam[] param = new DbParam[5];

            param[0] = new DbParam("p_PaymentId", entity.PaymentId, MySqlDbType.Int32);
            param[1] = new DbParam("p_StoreId", entity.StoreId, MySqlDbType.Int32);
            param[2] = new DbParam("p_Status", entity.Status, MySqlDbType.VarChar);
            param[3] = new DbParam("p_Mode", entity.Mode, MySqlDbType.VarChar);
            param[4] = new DbParam("p_Amount", entity.Amount, MySqlDbType.Decimal);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblpayment_UpdatePayment", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Payment>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Payment>> PaymentList()
        {
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblpayment_GetPayment", null, 30);

            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Payment>();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Payment>> ListPagignationPayment(int PageIndex, int PageSize)
        {
            DbParam[] param = new DbParam[2];

            param[0] = new DbParam("p_PageIndex", PageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", PageSize, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblpayment_ListPaginationPayment", param, 30);

            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Payment>();
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Payment>> ListFilterPaginationPayment(int PageIndex, int PageSize, Payment entity)
        {
            DbParam[] param = new DbParam[6];

            param[0] = new DbParam("p_PageIndex", PageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", PageSize, MySqlDbType.Int32);
            param[2] = new DbParam("p_PaymentId", entity.PaymentId, MySqlDbType.Int32);
            param[3] = new DbParam("p_Mode", entity.Mode, MySqlDbType.VarChar);
            param[4] = new DbParam("p_Status", entity.Status, MySqlDbType.VarChar);
            param[5] = new DbParam("p_Remarks", entity.Remarks, MySqlDbType.VarChar);


            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblPayment_ListFilterPaginationPayment", param, 30);

            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Payment>();
            }
            else
            {
                return null;
            }
        }
    }
}