using System;

namespace LLM.Store.ApplicationCore.Entities
{
    public class DetailStationMasterResponse
    {
        public string station_code { get; set; }
        public string station_name { get; set; }
        public int account_id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime created_on { get; set; }
        public int created_by { get; set; }
        public DateTime modified_on { get; set; }
        public int modified_by { get; set; }
        public string msg { get; set; }
    }
}
