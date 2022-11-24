using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace obilet.MVC.Helpers
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;


            var _deviceId = (from c in userPrincipal.Claims
                             where c.Type == "DeviceId"
                             select c.Value).FirstOrDefault();

            var _sessionId = (from c in userPrincipal.Claims
                              where c.Type == "SessionId"
                              select c.Value).FirstOrDefault();

            if (string.IsNullOrEmpty(_deviceId) || string.IsNullOrEmpty(_sessionId))
            {
                context.RejectPrincipal();
               

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
