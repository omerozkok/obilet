﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Entities.Model.Journey
{
    public class BusJourneyModel
    {
        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
