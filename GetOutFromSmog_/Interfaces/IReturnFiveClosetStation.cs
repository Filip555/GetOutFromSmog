using GetOutFromSmog_.Models;
using System.Collections.Generic;

namespace GetOutFromSmog_.Interfaces
{
    interface IReturnNearestStation
    {
        List<ParseJsonToList> ReturnNearestStation(List<ParseJsonToList> model, double userLatitudes, double userLongitudes);
    }
}
