using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using obilet.Business.Abstract;
using obilet.Entities;
using obilet.Entities.Dtos.Auth;
using obilet.Entities.Dtos.Auth.SessionResult;
using obilet.Entities.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wangkanai.Detection;

namespace obilet.Business.Concrete
{
    public class SessionManager : ISessionService
    {
        private IApiService _apiService;
        private readonly IBrowserResolver _browser;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IApiService apiService, IBrowserResolver browser, IHttpContextAccessor httpContextAccessor)
        {
            _browser = browser;
            _apiService = apiService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResultModel<SessionDataResultModel>> GetSession()
        {

            string _ip = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

            try
            {
                AuthModal session = new AuthModal()
                {
                    Type = 1,
                    Connection = new AuthConnectionModel { Ip = _ip, Port = "5117" },
                    Browser = new AuthBrowserModel { Name = _browser.Browser.Type.ToString() , Version = _browser.Browser.Version?.ToString() }
                };
                return await _apiService.Post<BaseResultModel<SessionDataResultModel>>(EndPoints.GetSession, session);               
            }
            catch (Exception ex)
            {
                return null;
            }


        }

       

    }
}
