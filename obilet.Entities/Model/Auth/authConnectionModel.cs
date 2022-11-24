using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Entities.Dtos.Auth
{
    public class AuthConnectionModel
    {

        [JsonProperty(PropertyName = "ip-address")]
        public string Ip { get; set; }
        [JsonProperty(PropertyName = "port")]
        public string Port { get; set; }
    }
}
