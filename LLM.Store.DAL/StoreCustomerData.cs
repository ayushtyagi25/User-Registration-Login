using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.Utils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LLM.Store.DAL
{
    public class StoreCustomerData : IStoreCustomerData
    {
        public async Task<StoreCustomer> AddStoreCustomer(StoreCustomer entity)
        {
            DbParam[] param = new DbParam[17];
            param[0] = new DbParam("p_StoreId", entity.StoreId, MySqlDbType.Int32);
            param[1] = new DbParam("p_CustomerId", entity.CustomerId, MySqlDbType.Int32);
            param[2] = new DbParam("p_Name", entity.Name, MySqlDbType.VarChar);
            param[3] = new DbParam("p_ContactNo", entity.ContactNo, MySqlDbType.VarChar);
            param[4] = new DbParam("p_FlatNo", entity.FlatNo, MySqlDbType.VarChar);
            param[5] = new DbParam("p_Block", entity.Block, MySqlDbType.VarChar);
            param[6] = new DbParam("p_LocationId", entity.LocationId, MySqlDbType.Int32);
            param[7] = new DbParam("p_NewCustomer", entity.NewCustomer, MySqlDbType.Bit);
            param[8] = new DbParam("p_CreditAllowed", entity.CreditAllowed, MySqlDbType.Bit);
            param[9] = new DbParam("p_CreditDays", entity.CreditDays, MySqlDbType.Int32);
            param[10] = new DbParam("p_CreatedBy", entity.CreatedBy, MySqlDbType.Int32);
            param[11] = new DbParam("p_ModifiedBy", entity.ModifiedBy, MySqlDbType.Int32);
            param[12] = new DbParam("p_PendingOrders", entity.PendingOrders, MySqlDbType.Int32);
            param[13] = new DbParam("p_Outstanding", entity.Outstanding, MySqlDbType.Decimal);
            param[14] = new DbParam("p_Overdue", entity.Overdue, MySqlDbType.Decimal);
            param[15] = new DbParam("p_PendingCashEntry", entity.PendingCashEntry, MySqlDbType.Int32);
            param[16] = new DbParam("p_PendingCashEntryAmount", entity.PendingCashEntryAmount, MySqlDbType.Decimal);
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorecustomer_AddStoreCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<StoreCustomer>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<StoreCustomer> UpdateStoreCustomer(int StoreCustomerId)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_StoreCustomerId", StoreCustomerId, MySqlDbType.Int32);


            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorecustomer_UpdateStoreCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<StoreCustomer>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<StoreCustomer> GetStoreCustomer(int StoreCustomerId)
        {
            DbParam[] param = new DbParam[1];
            param[0] = new DbParam("p_StoreCustomerId", StoreCustomerId, MySqlDbType.Int32);
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorecustomer_GetStoreCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<StoreCustomer>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<StoreCustomer> DeleteStoreCustomer(int StoreCustomerId)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_StoreCustomerId", StoreCustomerId, MySqlDbType.Int32);
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorecustomer_DeleteStoreCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<StoreCustomer>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<List<StoreCustomer>> ListStoreCustomer()
        {
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorecustomer_ListStoreCustomer", null, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<StoreCustomer>();
            }
            else
            {
                return null;
            }
        }
        public async Task<List<StoreCustomer>> ListPaginationStoreCustomer(int pageIndex, int pageSize)
        {
            DbParam[] param = new DbParam[2];
            param[0] = new DbParam("p_PageIndex", pageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", pageSize, MySqlDbType.Int32);

            List<StoreCustomer> entity = new List<StoreCustomer>();
            DataSet dt = await DBUtil.GetDataSetAsync("usp_tblstorecustomer_ListPaginationStoreCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    return dt.Tables[0].ConvertDataTable<StoreCustomer>();
                }
            }
            else
            {
                return null;
            }
            return null;

        }
        public async Task<List<StoreCustomer>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int StoreCustomerId, string Name, string ContactNo, string FlatNo, string Block)
        {
            DbParam[] param = new DbParam[7];
            param[0] = new DbParam("p_PageIndex", pageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", pageSize, MySqlDbType.Int32);
            param[2] = new DbParam("p_StoreCustomerId", StoreCustomerId, MySqlDbType.Int32);
            param[3] = new DbParam("p_Name", Name, MySqlDbType.VarChar);
            param[4] = new DbParam("p_ContactNo", ContactNo, MySqlDbType.VarChar);
            param[5] = new DbParam("p_FlatNo", FlatNo, MySqlDbType.VarChar);
            param[6] = new DbParam("p_Block", Block, MySqlDbType.VarChar);

            List<StoreCustomer> entity = new List<StoreCustomer>();
            DataSet dt = await DBUtil.GetDataSetAsync("usp_tblstorecustomer_ListPaginationFilterStoreCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    return dt.Tables[0].ConvertDataTable<StoreCustomer>();
                }
            }
            else
            {
                return null;
            }
            return null;

        }




    }
}


