using GetOutFromSmog_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOutFromSmog_.Models
{
public class ReturnNearestStationsIn100Km : IReturnNearestStation
{
    public List<ParseJsonToList> ReturnNearestStation(List<ParseJsonToList> model, double userLatitudes, double userLongitudes)
    {
        Func<double, double, double, double, double> calculateDistanceToKm = (double _stationLatitudes, double _stationLongtitudes, double _userLatitudes, double _userLongtitudes) =>
            {
                var R = 6372.8; // In kilometers
    var dLat = toRadians(_stationLatitudes - _userLatitudes);
                var dLon = toRadians(_stationLongtitudes - _userLongtitudes);
                _userLatitudes = toRadians(_userLatitudes);
                _stationLatitudes = toRadians(_stationLatitudes);

                var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(_stationLatitudes) * Math.Cos(_userLatitudes);
                var c = 2 * Math.Asin(Math.Sqrt(a));
                return Math.Round(R * 2 * Math.Asin(Math.Sqrt(a)), 3);
            };
        var filtredModel = model.Where(x =>
        {
            if (x?.LatAndLong?.Latitudes == null || x?.LatAndLong?.Longitudes == null) return false;
            var distanceInKmFromUserToStation = calculateDistanceToKm(x.LatAndLong.Latitudes, x.LatAndLong.Longitudes, userLatitudes, userLongitudes);
            x.DistanceBetweenUserAndStation = distanceInKmFromUserToStation;
            return (distanceInKmFromUserToStation < 100);
        }).ToList();
        return filtredModel;
    }
    public double toRadians(double angle)
    {
        return Math.PI * angle / 180.0;
    }
}
}