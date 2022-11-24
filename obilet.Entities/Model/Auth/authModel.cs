using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Entities.Dtos.Auth
{
    public class AuthModal
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("connection")]
        public AuthConnectionModel Connection { get; set; }
        [JsonProperty("browser")]
        public AuthBrowserModel Browser { get; set; }

    }
}
