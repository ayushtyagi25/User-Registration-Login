using System.ComponentModel.DataAnnotations;

namespace LLM.Store.ApplicationCore.Entities
{
    public class UpdateStationMasterRequest
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(50, ErrorMessage = " Station Code must be between 1 and 50 characters", MinimumLength = 1)]
        public string station_code { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, ErrorMessage = " Station Name must be between 1 and 100 characters", MinimumLength = 1)]
        public string station_name { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(30, ErrorMessage = " Latitude must be between 1 and 30 characters", MinimumLength = 1)]
        public string latitude { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(30, ErrorMessage = " Longitude  must be between 1 and 30 characters", MinimumLength = 1)]
        public string longitude { get; set; }
    }
}
