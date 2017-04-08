using GetOutFromSmog_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOutFromSmog_.Models
{
public class CleanestAir : ICleanestAir
{
    public ParseJsonToList CalculateCleanestAir(List<ParseJsonToList> model)
    {
        ParseJsonToList mod=null;
        float LowestValue = 0f;
        foreach (var item in model)
        {
            float currentValue = 0f;
            foreach (var item2 in item.ListMeasurements)
            {
                currentValue = float.Parse(item2.FirstOrDefault().Value);
            }
            if(currentValue< LowestValue || LowestValue==0)
            {
                LowestValue = currentValue;
                mod = item;
            }
        }
        return mod;
    }
}
}