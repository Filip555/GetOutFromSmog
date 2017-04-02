using GetOutFromSmog_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetOutFromSmog_.Interfaces
{
    public interface IParseJsonToListAboutMeasureStation
    {
        List<ParseJsonToList> ParseStringToArray();
    }
}
