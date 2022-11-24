using Newtonsoft.Json;
using obilet.Business.Abstract;
using obilet.Entities.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Concrete
{
    public class ApiManager: IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ApiManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> Post<T>(string Url, object model)
        {
            try
            {
                HttpContent httpContent = null;
                if (model != null) httpContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient("obilet");
                var result = await client.PostAsync(Url, httpContent);

                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    if (result.StatusCode != System.Net.HttpStatusCode.TooManyRequests)
                    {
                        throw new Exception("Result Error Url :: " + Url + Environment.NewLine +
                                                               "Status Code :: " + result.StatusCode + Environment.NewLine +
                                                               "Detail :: " + result.ReasonPhrase);
                    }                 
                }

                return JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                
            }
            catch (Exception ex)
            {
                throw new Exception("ApiManager convert model error :: " + ex.Message ); 
            }

        }

      
    }
}
