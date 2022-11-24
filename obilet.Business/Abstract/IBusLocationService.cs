using obilet.Entities.Dtos.BusLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Abstract
{
    public interface IBusLocationService
    {
        List<BusLocationResultModel> GetBusLocations();
    }
}
