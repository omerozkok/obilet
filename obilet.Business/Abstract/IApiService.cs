using obilet.Entities.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Abstract
{
    public interface IApiService
    {
        Task<T> Post<T>(string Url, object model);
    }
}
