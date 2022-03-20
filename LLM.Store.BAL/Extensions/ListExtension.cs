using LLM.Store.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.BAL.Extensions
{
    public static class ListExtension
    {
        public static ListStationMasterResponse ToEntity(this ListStationMasterResponse entity)
        {

            return (entity == null) ? null : new ListStationMasterResponse()
            {

                station_code = entity.station_code,
                station_name = entity.station_name,
                account_id = entity.account_id,
                latitude = entity.latitude,
                longitude = entity.longitude
            };
        }
        public static List<ListStationMasterResponse> ToEntityResponse(this List<ListStationMasterResponse> entity)
        {
            List<ListStationMasterResponse> objects = new List<ListStationMasterResponse>();
            if (entity != null)
            {
                foreach (ListStationMasterResponse obj in entity)
                {
                    ListStationMasterResponse obj3 = new ListStationMasterResponse()
                    {


                        station_code = obj.station_code,
                        station_name = obj.station_name,
                        account_id = obj.account_id,
                        latitude = obj.latitude,
                        longitude = obj.longitude,
                    };

                    objects.Add(obj3);
                }
            }
            return objects;
        }
    }
}     