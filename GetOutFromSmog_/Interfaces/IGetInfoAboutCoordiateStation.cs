using GetOutFromSmog_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOutFromSmog_.Interfaces
{
    interface IGetInfoAboutCoordiateStation
    {
        List<ParseJsonToList> GetLongitudeAfterAdress(List<ParseJsonToList> adress);
    }
}