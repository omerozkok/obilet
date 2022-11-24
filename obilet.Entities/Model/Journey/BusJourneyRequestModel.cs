using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Entities.Model.Journey
{
    public class BusJourneyRequestModel
    {
        [JsonProperty("origin-id")]
        [Required(ErrorMessage = "Başlangıç noktası seçimi zorunludur..")]
        public int OriginId { get; set; }

        [JsonProperty("destination-id")]
        [Required(ErrorMessage = "Varış noktası seçimi zorunludur..")]
        public int DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public DateTime departureDate { get; set; }
    }
}
