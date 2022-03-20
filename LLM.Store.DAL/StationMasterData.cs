using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.Utils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace LLM.Store.DAL
{
    public class StationMasterData : IStationMasterData
    {
        public async Task<CreateStationMasterResponse> CreateStationMaster(CreateStationMasterRequest entity, Token TokenInfo)
        {
            DbParam[] param = new DbParam[7];
            param[0] = new DbParam("p_station_code", entity.station_code, MySqlDbType.VarChar);
            param[1] = new DbParam("p_station_name", entity.station_name, MySqlDbType.VarChar);
            param[2] = new DbParam("p_account_id", entity.account_id, MySqlDbType.Int32);
            param[3] = new DbParam("p_latitude", entity.latitude, MySqlDbType.VarChar);
            param[4] = new DbParam("p_longitude", entity.longitude, MySqlDbType.VarChar);
            param[5] = new DbParam("p_created_by", TokenInfo.created_by, MySqlDbType.Int32);
            param[6] = new DbParam("p_modified_by", TokenInfo.modified_by, MySqlDbType.Int32);

            DataTable dt = await DBUtil.GetDataTableAsync("usp_StationMaster_Create", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<CreateStationMasterResponse>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<UpdateStationMasterResponse> UpdateStationMaster(UpdateStationMasterRequest entity)
        {
            DbParam[] param = new DbParam[4];

            param[0] = new DbParam("p_station_code", entity.station_code, MySqlDbType.VarChar);
            param[1] = new DbParam("p_station_name", entity.station_name, MySqlDbType.VarChar);
            param[2] = new DbParam("p_latitude", entity.latitude, MySqlDbType.VarChar);
            param[3] = new DbParam("p_longitude", entity.longitude, MySqlDbType.VarChar);



            DataTable dt = await DBUtil.GetDataTableAsync("usp_StationMaster_Update", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<UpdateStationMasterResponse>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<DetailStationMasterResponse> GetDetailsStationMaster(string station_code)
        {
            DbParam[] param = new DbParam[1];
            param[0] = new DbParam("p_station_code", station_code, MySqlDbType.VarChar);
            DataTable dt = await DBUtil.GetDataTableAsync("usp_StationMaster_Details", param, 30);
            if (DBUtil.IsDataExists(dt))
            {
                return dt.ConvertDataTable<DetailStationMasterResponse>()[0];
            }
            else
            {
                return null;
            }
        }

        public async Task<(int, List<ListStationMasterResponse>)> ListStationMaster(int pageIndex, int pageSize, ListStationMasterRequest entity)
        {
            List<ListStationMasterResponse> StationMaster = new List<ListStationMasterResponse>();

            DbParam[] param = new DbParam[7];
            param[0] = new DbParam("p_PageIndex", pageIndex, MySqlDbType.Int32);
            param[1] = new DbParam("p_PageSize", pageSize, MySqlDbType.Int32);
            param[2] = new DbParam("p_station_code", entity.station_code, MySqlDbType.VarChar);
            param[3] = new DbParam("p_station_name", entity.station_name, MySqlDbType.VarChar);
            param[4] = new DbParam("p_account_id", entity.account_id, MySqlDbType.Int32);
            param[5] = new DbParam("p_latitude", entity.latitude, MySqlDbType.VarChar);
            param[6] = new DbParam("p_longitude", entity.longitude, MySqlDbType.VarChar);

            DataSet ds = await DBUtil.GetDataSetAsync("usp_StationMaster_ListPagination", param, 1800);
            if (DBUtil.IsDataExists(ds) && ds.Tables.Count > 1)
            {
                StationMaster = (from DataRow row in ds.Tables[0].Rows
                                 select new ListStationMasterResponse()
                                 {
                                     station_code = (DBUtil.ToString(row["station_code"])),
                                     station_name = (DBUtil.ToString(row["station_name"])),
                                     account_id = (DBUtil.ToInteger(row["account_id"])),
                                     latitude = (DBUtil.ToString(row["latitude"])),
                                     longitude = (DBUtil.ToString(row["longitude"]))
                                     

                                  }).ToList();

                return (DBUtil.ToInteger(ds.Tables[1].Rows[0]["TotalRecord"]), StationMaster);
            }
            else
            {
                return (0, null);
            }
        }
    }
}

