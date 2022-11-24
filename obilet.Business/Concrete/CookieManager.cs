using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using obilet.Business.Abstract;
using obilet.Entities.Dtos.Auth;
using obilet.Entities.Dtos.Auth.SessionResult;
using obilet.Entities.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Concrete
{
    public class CookieManager : ICookieService
    {
        private readonly IHttpContextAccessor _accessor;
        public CookieManager(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public async Task<bool> CreateCookie(SessionDataResultModel model)
        {
            if (model == null) return false;

            var claimsIdentity = new ClaimsIdentity(CreateClaims(model), CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false
            };
            
            await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(claimsIdentity),
                                          authProperties);
            return true;
        }
        public async Task DeleteCookie()
        {
            await _accessor.HttpContext.SignOutAsync();
        }

        public List<Claim> CreateClaims(SessionDataResultModel model)
        {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "guest"),
                    new Claim(ClaimTypes.Name, "guest"),
                    new Claim("SessionId", model.SessionId),
                    new Claim("DeviceId", model.DeviceId),
                    new Claim("IpCountry", model.IpCountry)
                };
        }

        public BaseRequestModel GetRequestModel()
        {
            BaseRequestModel model = new BaseRequestModel();
            model.DeviceSession = GetDeviceSession();

            return model;
        }

        public authSession GetDeviceSession()
        {
            authSession model = new authSession();
            try
            {
                model.DeviceId = (_accessor.HttpContext.User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "DeviceId").FirstOrDefault().Value; 
                model.SessionId = (_accessor.HttpContext.User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "SessionId").FirstOrDefault().Value; 
            }
            catch {
                model = new authSession();
            }

            return model;
        }
    }
}
