using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.Utils;
using LLM.Store.ApplicationCore.ViewModels;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;

namespace LLM.Store.DAL
{
    public class UserData  : IUserData
    {
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
            DataSet ds = await DBUtil.GetDataSetAsync("usp_tbluserayush_UserRegistration", param, 1800);

            if (DBUtil.IsDataExists(ds))
            {


                if (ds.Tables[0].Rows.Count > 0)

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CreateResponseViewModel user = new CreateResponseViewModel();
                        user.UserId = DBUtil.ToInteger(row["UserId"]);
                        user.UserName = DBUtil.ToString(row["UserName"]);
                        user.msg = DBUtil.ToString(row["msg"]);
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
        public async Task<LoginAuthenticationResponse> LoginUser(LoginAuthenticationRequest entity)
        {
            DbParam[] param = new DbParam[2];

            param[0] = new DbParam("p_UserName", entity.UserName, MySqlDbType.VarChar);
            param[1] = new DbParam("p_UserPassword", entity.UserPassword, MySqlDbType.VarChar);
            DataSet ds = await DBUtil.GetDataSetAsync("usp_tbluserayush_UserLogin", param, 1800);

            if (DBUtil.IsDataExists(ds))
            {
                if (ds.Tables[0].Rows.Count > 0)


                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LoginAuthenticationResponse user = new LoginAuthenticationResponse();

                        user.UserName = DBUtil.ToString(row["UserName"]);
                        user.msg = DBUtil.ToString(row["msg"]);


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
