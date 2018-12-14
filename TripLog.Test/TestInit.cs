namespace TripLog.Test
{
    using System.Collections.Generic;

    using Moq;

    using TripLog.Models;
    using TripLog.Services;
    using TripLog.ViewModels;
    using TripLog.Views;

    public static class TestInit
    {
        public static Mock<GeoLocationService> MockedGeoLocationService = new Mock<GeoLocationService>();
        public static Mock<TripLogDataService> MockedTripLogDataService = new Mock<TripLogDataService>();
        public static ViewModelFactory ViewModelFactory = new ViewModelFactory(MockedGeoLocationService.Object, MockedTripLogDataService.Object);
        public static ViewFactory ViewFactory = new ViewFactory(ViewModelFactory);

        public static GeoCoords FakeCoordinates;
        public static IList<TripLogEntry> FakeTripLogEntryCollection;

        static TestInit()
        {
            FakeCoordinates = new GeoCoords();

            FakeCoordinates.Latitude = 123;
            FakeCoordinates.Longitude = 321;

            FakeTripLogEntryCollection = new List<TripLogEntry>() { new TripLogEntry() };

            MockedTripLogDataService.Setup(query => query.ReadAllEntriesAsync()).
               ReturnsAsync(FakeTripLogEntryCollection);

            MockedGeoLocationService.Setup(query => query.PullCoordinatesAsync()).
               ReturnsAsync(FakeCoordinates);
        }
    }
}
