﻿
using System.Threading.Tasks;
using CoreLocation;

using TripLog.Models;
using TripLog.Services;
using UIKit;

namespace TripLog.iOS.Services
{
    public class IosLocationService : GeoLocationService
    {
        private TaskCompletionSource<CLLocation> _locationTaskCompletion;

        public async Task<GeoCoords> PullCoordinatesAsync()
        {
            var locationManager = new CLLocationManager();
            _locationTaskCompletion = new TaskCompletionSource<CLLocation>();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locationManager.RequestWhenInUseAuthorization();
            }

            locationManager.LocationsUpdated += OnLocationUpdated;

            locationManager.StartUpdatingLocation();

            var location = await _locationTaskCompletion.Task;

            var result = new GeoCoords();
            result.Latitude = location.Coordinate.Latitude;
            result.Longitude = location.Coordinate.Longitude;

            return result;
        }

        private void OnLocationUpdated(object sender, CLLocationsUpdatedEventArgs e)
        {
            _locationTaskCompletion.TrySetResult(e.Locations[0]);
        }
    }
}