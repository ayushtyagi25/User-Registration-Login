using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.Utils;
using LLM.Store.ApplicationCore.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LLM.Store.DAL
{
    public class CustomerData : ICustomerData
    {
        DataTable dt1;
        DataSet ds1;

        public CustomerData()
        {
            if (dt1 == null)
            {
                dt1 = new DataTable("Table");
                dt1.Columns.Add("Name");
                dt1.Columns.Add("Email");
                dt1.Columns.Add("Password");
                dt1.Columns.Add("LoginFailedCount");
            }
            if (ds1 == null)
            {
                ds1 = new DataSet("Dataset");
            }
            else
            {
                ds1.Tables.Add(dt1);
            }
        }
        public async Task<Customer> AddCustomer(Customer entity)
        {
            DbParam[] param = new DbParam[12];
            param[0] = new DbParam("p_CustomerId", entity.CustomerId, MySqlDbType.Int32);
            param[1] = new DbParam("p_OperatorId", entity.OperatorId, MySqlDbType.Int32);
            param[2] = new DbParam("p_Name", entity.Name, MySqlDbType.VarChar);
            param[3] = new DbParam("p_StoreId", entity.StoreId, MySqlDbType.Int32);
            param[4] = new DbParam("p_PendingOrders", entity.PendingOrders, MySqlDbType.Int32);
            param[5] = new DbParam("p_Outstanding", entity.Outstanding, MySqlDbType.Decimal);
            param[6] = new DbParam("p_Overdue", entity.Overdue, MySqlDbType.Decimal);
            param[7] = new DbParam("p_Savings", entity.Savings, MySqlDbType.Decimal);
            param[8] = new DbParam("p_CmSavings", entity.CmSaving, MySqlDbType.Decimal);
            param[9] = new DbParam("p_PendingCashEntry", entity.PendingCashEntry, MySqlDbType.Decimal);
            param[10] = new DbParam("p_PendingCashEntryAmount", entity.PendingCashEntryAmount, MySqlDbType.Decimal);
            param[11] = new DbParam("p_WalletId", entity.WalletId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblcustomer_AddCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Customer>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<Customer> UpdateCustomer(Customer entity)
        {
            DbParam[] param = new DbParam[1];
            param[0] = new DbParam("p_CustomerId", entity.CustomerId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblcustomer_UpdateCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Customer>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<Customer> DeleteCustomer(int CustomerId)
        {
            DbParam[] param = new DbParam[1];

            param[0] = new DbParam("p_CustomerId", CustomerId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblcustomer_DeleteCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Customer>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Customer>> ListCustomer()
        {
            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblcustomer_ListCustomer", null, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Customer>();
            }
            else
            {
                return null;
            }
        }
        public async Task<Customer> GetCustomer(int CustomerId)
        {
            DbParam[] param = new DbParam[1];
            param[0] = new DbParam("p_CustomerId", CustomerId, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_tblcustomer_GetCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<Customer>()[0];
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Customer>> ListPaginationFilterStoreCustomer(int pageIndex, int pageSize, int CustomerId, int OperatorId, string Name)
        {
            DbParam[] param = new DbParam[5];
            param[0] = new DbParam("p_PageIndex", pageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", pageSize, MySqlDbType.Int32);
            param[2] = new DbParam("p_CustomerId", CustomerId, MySqlDbType.Int32);
            param[3] = new DbParam("p_OperatorId", OperatorId, MySqlDbType.Int32);
            param[4] = new DbParam("p_Name", Name, MySqlDbType.VarChar);



            List<Customer> entity = new List<Customer>();
            DataSet dt = await DBUtil.GetDataSetAsync("usp_tblcustomer_ListFilterPaginationCustomer", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    return dt.Tables[0].ConvertDataTable<Customer>();
                }
            }
            else
            {
                return null;
            }
            return null;

        }

        //public async Task<CreateResponseViewModel> CreateCustomer(CreateRequestViewModel entity)
        //{
        //    DbParam[] param = new DbParam[12];
        //    param[0] = new DbParam("p_UserId", entity.UserId, MySqlDbType.Int32);
        //    param[1] = new DbParam("p_UserName", entity.UserName, MySqlDbType.VarChar);
        //    param[2] = new DbParam("p_UserPassword", entity.UserPassword, MySqlDbType.VarChar);
        //    param[3] = new DbParam("p_Gender", entity.Gender, MySqlDbType.VarChar);
        //    param[4] = new DbParam("p_MobileNumber", entity.MobileNumber, MySqlDbType.VarChar);
        //    param[5] = new DbParam("p_CreatedOn", entity.CreatedOn, MySqlDbType.DateTime);
        //    param[6] = new DbParam("p_LastRequestTime", entity.LastRequestTime, MySqlDbType.DateTime);
        //    param[7] = new DbParam("p_CreatedIP", entity.CreatedIP, MySqlDbType.VarChar);
        //    param[8] = new DbParam("p_LastLoginIP", entity.LastLoginIP, MySqlDbType.VarChar);
        //    param[9] = new DbParam("p_LastLoginDate", entity.LastLoginDate, MySqlDbType.DateTime);
        //    param[10] = new DbParam("p_LoginFailedCount", entity.LoginFailedCount, MySqlDbType.Int32);
        //    param[11] = new DbParam("p_IsUserBlock", entity.IsUserBlock, MySqlDbType.Int32);
        //    param[12] = new DbParam("p_LastLoginIP", entity.LastLoginIP, MySqlDbType.VarChar);

        //    DataTable dt = await DBUtil.GetDataTableAsync("usp_update", param, 30);
        //    if (DBUtil.IsDataExists(dt))
        //    {
        //        return dt.ConvertDataTable<CreateResponseViewModel>()[0];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public async Task<CreateResponseViewModel> CreateUser(CreateRequestViewModel entity, string CreatedIP, int LoginFailedCount, int IsUserBlock)
        {
            DbParam[] param = new DbParam[7];

            param[0] = new DbParam("p_UserName", entity.UserName, MySqlDbType.VarChar);
            param[1] = new DbParam("p_UserPassword", entity.UserPassword, MySqlDbType.VarChar);
            param[2] = new DbParam("p_Gender", entity.Gender, MySqlDbType.VarChar);
            param[3] = new DbParam("p_MobileNumber", entity.MobileNumber, MySqlDbType.VarChar);
            param[4] = new DbParam("p_CreatedIP", CreatedIP, MySqlDbType.VarChar);
            param[5] = new DbParam("p_LoginFailedCount", LoginFailedCount, MySqlDbType.Int32);
            param[6] = new DbParam("p_IsUserBlock", IsUserBlock, MySqlDbType.Int32);

            // DataSet code  
            DataSet ds = await DBUtil.GetDataSetAsync("usp_tblGet_Insert", param, 1800);

            if (DBUtil.IsDataExists(ds))
            {


                if (ds.Tables[0].Rows.Count > 0)

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CreateResponseViewModel user = new CreateResponseViewModel();
                        user.UserId = DBUtil.ToInteger(row["UserId"]);
                        user.UserName = DBUtil.ToString(row["UserName"]);

                        return user;
                    }

            }
            else
            {
                return null;
            }
            return null;
        }
        //Login Api
        public async Task<LoginAuthentication> LoginUser(LoginAuthentication entity)
        {
            DbParam[] param = new DbParam[2];

            param[0] = new DbParam("p_UserName", entity.UserName, MySqlDbType.VarChar);
        //    param[1] = new DbParam("p_UserPassword", entity.UserPassword, MySqlDbType.VarChar);
            DataSet ds = await DBUtil.GetDataSetAsync("usp_tblGetList", param, 1800);

            if (DBUtil.IsDataExists(ds))
            {
                if (ds.Tables[0].Rows.Count > 0)


                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LoginAuthentication user = new LoginAuthentication();

                        user.UserName = DBUtil.ToString(row["UserName"]);
                        //user.UserPassword = DBUtil.ToString(row["UserPassword"]);
              

                        return user;
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

