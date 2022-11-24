using obilet.Business.Abstract;
using obilet.Entities;
using obilet.Entities.Dtos.BusLocation;
using obilet.Entities.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Concrete
{
    public class BusLocationManager:IBusLocationService
    {
        private ICookieService _cookieService;
        private IApiService _apiService;
        public BusLocationManager(ICookieService cookieService, IApiService apiService)
        {
            _cookieService = cookieService;
            _apiService = apiService;
        }
        public List<BusLocationResultModel> GetBusLocations()
        {
            try
            {
                var requesModel = _cookieService.GetRequestModel();
                return _apiService.Post<BaseResultModel<List<BusLocationResultModel>>>(EndPoints.GetBusLocation, requesModel).Result.Data;

            }
            catch (System.Exception ex)
            {

                return new List<BusLocationResultModel>();
            }

        }
    }
}
