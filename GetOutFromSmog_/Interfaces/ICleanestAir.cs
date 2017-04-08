using GetOutFromSmog_.Models;
using System.Collections.Generic;

namespace GetOutFromSmog_.Interfaces
{
    public interface ICleanestAir
    {
        ParseJsonToList CalculateCleanestAir(List<ParseJsonToList> model);
    }
}
