namespace TripLog.Test
{
    using System.Threading.Tasks;

    using TripLog.Models;
    using TripLog.Services;

    public class MockedGeoLocationService : GeoLocationService
    {
        public Task<GeoCoords> PullCoordinatesAsync()
        {
           return new Task<GeoCoords>(Get);
        }

        public GeoCoords Get()
        {
            return TestInit.FakeCoordinates;
        }
    }
}
