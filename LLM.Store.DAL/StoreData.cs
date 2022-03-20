using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.DAL
{
    public class StoreData : IStoreData
    {
        public async Task<TblStore> AddStore(TblStore entity)
        {
            DbParam[] param = new DbParam[41];
            
            param[0] = new DbParam("p_StoreTypeId", entity.StoreTypeId, MySqlDbType.Int32);
            param[1] = new DbParam("p_StoreClassId", entity.StoreClassId, MySqlDbType.Int32);
            param[2] = new DbParam("p_OperatorId", entity.OperatorId, MySqlDbType.Int32);
            param[3] = new DbParam("p_Name", entity.Name, MySqlDbType.VarChar);
            param[4] = new DbParam("p_Description", entity.Description, MySqlDbType.VarChar);
            param[5] = new DbParam("p_ImagePath", entity.ImagePath, MySqlDbType.VarChar);
            param[6] = new DbParam("p_ContactName", entity.ContactName, MySqlDbType.VarChar);
            param[7] = new DbParam("p_ContactNo", entity.ContactNo, MySqlDbType.VarChar);
            param[8] = new DbParam("p_AddressLine1", entity.AddressLine1, MySqlDbType.VarChar);
            param[9] = new DbParam("p_AddressLine2", entity.AddressLine2, MySqlDbType.VarChar);
            param[10] = new DbParam("p_AddressLine3", entity.AddressLine3, MySqlDbType.VarChar);
            param[11] = new DbParam("p_City", entity.City, MySqlDbType.VarChar);
            param[12] = new DbParam("p_StateId", entity.StateId, MySqlDbType.Int32);
            param[13] = new DbParam("p_State", entity.State, MySqlDbType.VarChar);
            param[14] = new DbParam("p_Country", entity.Country, MySqlDbType.VarChar);
            param[15] = new DbParam("p_PostalCode", entity.PostalCode, MySqlDbType.VarChar);
            param[16] = new DbParam("p_IsActive", entity.IsActive, MySqlDbType.Bit);
            param[17] = new DbParam("p_CreatedOn", entity.CreatedOn, MySqlDbType.DateTime);
            param[18] = new DbParam("p_CreatedBy", entity.CreatedBy, MySqlDbType.Int32);
            param[19] = new DbParam("p_ModifiedOn", entity.ModifiedOn, MySqlDbType.DateTime);
            param[20] = new DbParam("p_ModifiedBy", entity.ModifiedBy, MySqlDbType.Int32);
            param[21] = new DbParam("p_CustOutstanding", entity.CustOutstanding, MySqlDbType.Decimal);
            param[22] = new DbParam("p_OpOutstanding", entity.OpOutstanding, MySqlDbType.Decimal);
            param[23] = new DbParam("p_TotalOrders", entity.TotalOrders, MySqlDbType.Int32);
            param[24] = new DbParam("p_CmOrders", entity.CmOrders, MySqlDbType.Int32);
            param[25] = new DbParam("p_TotalOrderAmount", entity.TotalOrderAmount, MySqlDbType.Decimal);
            param[26] = new DbParam("p_CmOrderAmount", entity.CmOrderAmount, MySqlDbType.Decimal);
            param[27] = new DbParam("p_PendingOrders", entity.PendingOrders, MySqlDbType.Int32);
            param[28] = new DbParam("p_TotalRewards", entity.TotalRewards, MySqlDbType.Decimal);
            param[29] = new DbParam("p_CmRewards", entity.CmRewards, MySqlDbType.Decimal);
            param[30] = new DbParam("p_TotalCash", entity.TotalCash, MySqlDbType.Int32);
            param[31] = new DbParam("p_CmCash", entity.CmCash, MySqlDbType.Int32);
            param[32] = new DbParam("p_TotalCashAmount", entity.TotalCashAmount, MySqlDbType.Decimal);
            param[33] = new DbParam("p_CmCashAmount", entity.CmCashAmount, MySqlDbType.Decimal);
            param[34] = new DbParam("p_PendingCashEntry", entity.PendingCashEntry, MySqlDbType.Int32);
            param[35] = new DbParam("p_PendingCashEntryAmount", entity.PendingCashEntryAmount, MySqlDbType.Decimal);
            param[36] = new DbParam("p_CmCallCount", entity.CmCallCount, MySqlDbType.Int32);
            param[37] = new DbParam("p_CmMissedCallCount", entity.CmMissedCallCount, MySqlDbType.Int32);
            param[38] = new DbParam("p_MissedCalls", entity.MissedCalls, MySqlDbType.Int32);
            param[39] = new DbParam("p_TotalCallCount", entity.TotalCallCount, MySqlDbType.Int32);
            param[40] = new DbParam("p_VirtualNumber", entity.VirtualNumber, MySqlDbType.VarChar);
            

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorelivesatish_AddStore", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<TblStore>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<TblStore> DeleteStore(int storeId)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_StoreId", storeId, MySqlDbType.Int32);
            

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorelivesatish_DeleteStore", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<TblStore>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<TblStore> GetStore(int storeId)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_StoreId", storeId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorelivesatish_GetStore", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<TblStore>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<List<TblStore>> StoreList(int pageIndex, int pageSize, TblStore entity)
        {
            DbParam[] param = new DbParam[8];

            param[0] = new DbParam("p_PageIndex", pageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", pageSize, MySqlDbType.Int32);
            param[2] = new DbParam("p_StoreId", entity.StoreId, MySqlDbType.Int32);
            param[3] = new DbParam("p_Name", entity.Name, MySqlDbType.VarChar);
            param[4] = new DbParam("p_ContactNo", entity.ContactNo, MySqlDbType.VarChar);
            param[5] = new DbParam("p_City", entity.City, MySqlDbType.VarChar);
            param[6] = new DbParam("p_State", entity.State, MySqlDbType.VarChar);
            param[7] = new DbParam("p_Country", entity.Country, MySqlDbType.VarChar);
           
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorelivesatish_StoreList", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<TblStore>();
            }
            else
            {
                return null;
            }
        }

        public async Task<TblStore> UpdateStore(int storeId)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_StoreId", storeId, MySqlDbType.Int32);
            

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblstorelivesatish_UpdateStore", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<TblStore>()[0];
            }
            else
            {
                return null;
            }
        }
    }
}
