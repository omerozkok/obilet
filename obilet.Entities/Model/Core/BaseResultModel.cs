﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Entities.Dtos.Core
{
    public class BaseResultModel<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("user-message")]
        public string UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }

        [JsonProperty("client-request-id")]
        public string ClientRequestId { get; set; }
    }
}
