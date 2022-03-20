namespace LLM.Store.ApplicationCore.Entities
{
    public class UpdateStationMasterResponse
    {
        public string station_code { get; set; }
        public string station_name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string msg { get; set; }
    }
}
