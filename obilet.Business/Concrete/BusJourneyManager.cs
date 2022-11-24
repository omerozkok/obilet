using obilet.Entities;
using obilet.Entities.Dtos.Core;
using obilet.Entities.Model.Journey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Abstract
{
    public class BusJourneyManager:IBusJourneyService
    {
        private ICookieService _cookieService;
        private IApiService _apiService;
        public BusJourneyManager(ICookieService cookieService, IApiService apiService)
        {
            _cookieService = cookieService;
            _apiService = apiService;
        }

        public List<BusJourneyResultModel> GetBusJourneys(BusJourneyRequestModel model)
        {
            try
            {              
                
                var requesModel = _cookieService.GetRequestModel();
                requesModel.Data = model;
                return _apiService.Post<BaseResultModel<List<BusJourneyResultModel>>>(EndPoints.GetBusJourneys, requesModel).Result.Data;

            }
            catch 
            {

                return new List<BusJourneyResultModel>();
            }
        }
    }
}
