using Newtonsoft.Json;
using obilet.Entities.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Entities.Dtos.Core
{
    public class BaseRequestModel
    {
        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";

        [JsonProperty("device-session")]
        public authSession DeviceSession { get; set; }
    }
}
