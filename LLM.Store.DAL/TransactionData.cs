using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.Utils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LLM.Store.DAL
{
    public class TransactionData : ITransactionData
    {
        public async Task<Transaction> AddTransaction(Transaction entity)
        {
            DbParam[] param = new DbParam[17];
            param[0] = new DbParam("p_TransactionId", entity.TransactionId, MySqlDbType.Int32);
            param[1] = new DbParam("p_OperatorId", entity.OperatorId, MySqlDbType.Int32);
            param[2] = new DbParam("p_StoreId", entity.StoreId, MySqlDbType.Int32);
            param[3] = new DbParam("p_StoreName", entity.StoreName, MySqlDbType.VarChar);
            param[4] = new DbParam("p_StoreCustomerId", entity.StoreCustomerId, MySqlDbType.Int32);
            param[5] = new DbParam("p_CustomerId", entity.CustomerId, MySqlDbType.Int32);
            param[6] = new DbParam("p_CustomerName", entity.CustomerName, MySqlDbType.VarChar);
            param[7] = new DbParam("p_ContactNo", entity.ContactNo, MySqlDbType.VarChar);
            param[8] = new DbParam("p_Date", entity.Date, MySqlDbType.DateTime);
            param[9] = new DbParam("p_Category", entity.Category, MySqlDbType.VarChar);
            param[10] = new DbParam("p_Type", entity.Type, MySqlDbType.VarChar);
            param[11] = new DbParam("p_SubType", entity.SubType, MySqlDbType.VarChar);
            param[12] = new DbParam("p_ReferenceNo", entity.ReferenceNo, MySqlDbType.Int32);
            param[13] = new DbParam("p_Description", entity.Description, MySqlDbType.VarChar);
            param[14] = new DbParam("p_Amount", entity.Amount, MySqlDbType.Decimal);
            param[15] = new DbParam("p_CreatedOn", entity.CreatedOn, MySqlDbType.DateTime);
            param[16] = new DbParam("p_CreatedBy", entity.CreatedBy, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tbltransaction_AddTransaction", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Transaction>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<Transaction> DeleteTransaction(Transaction entity)
        {
            DbParam[] param = new DbParam[2];

            param[0] = new DbParam("p_CustomerName", entity.CustomerName, MySqlDbType.VarChar);
            param[1] = new DbParam("p_ContactNo", entity.ContactNo, MySqlDbType.VarChar);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tbltransaction_DeleteTransaction", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Transaction>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<Transaction> GetTransaction(int TransactionId)
        {
            DbParam[] param = new DbParam[1];
            param[0] = new DbParam("p_TransactionId", TransactionId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tbltransaction_GetTransaction", param, 30);

            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Transaction>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Transaction>> TransactionList()
        {
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tbltransaction_GetTransaction", null, 30);

            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Transaction>();
            }
            else
            {
                return null;
            }
        }

        public async Task<Transaction> UpdateTransaction(Transaction entity)
        {
            if (entity.CustomerName == "Sidra tul")
            {
                entity.CustomerName = "Shrishti";
            }
            else
            {
                entity.CustomerName = "Shrishti kumari";
            }
            DbParam[] param = new DbParam[6];

            param[0] = new DbParam("p_TransactionId", entity.TransactionId, MySqlDbType.Int32);
            param[1] = new DbParam("p_CustomerName", entity.CustomerName, MySqlDbType.VarChar);
            param[2] = new DbParam("p_ContactNo", entity.ContactNo, MySqlDbType.VarChar);
            param[3] = new DbParam("p_StoreName", entity.StoreName, MySqlDbType.VarChar);
            param[4] = new DbParam("p_SubType", entity.SubType, MySqlDbType.VarChar);
            param[5] = new DbParam("p_ReferenceNo", entity.ReferenceNo, MySqlDbType.Int32);


            DataTable dt = await DBUtil.GetDataTableAsync("usp_tbltransaction_UpdateTransaction", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Transaction>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Transaction>> ListPaginationTransaction(int pageIndex, int pageSize)
        {
            DbParam[] param = new DbParam[2];

            param[0] = new DbParam("p_PageIndex", pageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", pageSize, MySqlDbType.Int32);
           

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tbltransaction_ListPaginationTransaction", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Transaction>();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Transaction>> ListFilterPaginationTransaction(int pageIndex, int pageSize, Transaction entity)
        {
            DbParam[] param = new DbParam[6];

            param[0] = new DbParam("p_PageIndex", pageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", pageSize, MySqlDbType.Int32);
            param[2] = new DbParam("p_TransactionId", entity.TransactionId, MySqlDbType.Int32);
            param[3] = new DbParam("p_StoreName", entity.StoreName, MySqlDbType.VarChar);
            param[4] = new DbParam("p_ContactNo", entity.ContactNo, MySqlDbType.VarChar);
            param[5] = new DbParam("p_CustomerName", entity.CustomerName, MySqlDbType.VarChar);


            DataTable dt = await DBUtil.GetDataTableAsync("usp_tbltransaction_ListFilterPaginationTransaction", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Transaction>();
            }
            else
            {
                return null;
            }
        }
    }
}
