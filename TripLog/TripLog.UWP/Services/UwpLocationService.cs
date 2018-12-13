using System;

using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Windows.Devices.Geolocation;

namespace TripLog.UWP.Services
{
    public class UwpLocationService : GeoLocationService
    {
        public async Task<GeoCoords> PullCoordinatesAsync()
        { 
            var locator = new Geolocator();
            var coordinates = await locator.GetGeopositionAsync();

            GeoCoords result = new GeoCoords();
            result.Latitude = coordinates.Coordinate.Point.Position.Latitude;
            result.Longitude = coordinates.Coordinate.Point.Position.Longitude;

            return result;
        }
    }
}
