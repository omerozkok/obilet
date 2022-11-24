using obilet.Entities.Model.Journey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obilet.Business.Abstract
{
    public interface IBusJourneyService
    {
        List<BusJourneyResultModel> GetBusJourneys(BusJourneyRequestModel model);
    }
}
