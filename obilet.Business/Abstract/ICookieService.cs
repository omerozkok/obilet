using obilet.Entities.Dtos.Auth.SessionResult;
using obilet.Entities.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Abstract
{
    public interface ICookieService
    {
        Task<bool> CreateCookie(SessionDataResultModel model);
        Task DeleteCookie();
        BaseRequestModel GetRequestModel();
    }
}
