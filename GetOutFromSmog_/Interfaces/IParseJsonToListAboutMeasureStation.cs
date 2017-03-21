using GetOutFromSmog_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetOutFromSmog_.Interfaces
{
    interface IParseJsonToListAboutMeasureStation
    {
        List<ParseJsonToList> ParseStringToArray();
    }
}
