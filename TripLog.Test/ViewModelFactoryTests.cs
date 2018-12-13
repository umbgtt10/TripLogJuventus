using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Test
{
    public class MockedGeoLocationService : GeoLocationService
    {
        public Task<GeoCoords> PullCoordinatesAsync()
        {
            return new Task<GeoCoords>(Get);
        }

        public GeoCoords Get()
        {
            return new GeoCoords();
        }
    }

    [TestClass]
    public class ViewModelFactoryTests
    {
        public static Mock<GeoLocationService> MockedGeoLocationService = new Mock<GeoLocationService>();
        public static ViewModelFactory ViewModelFactory = new ViewModelFactory(MockedGeoLocationService.Object);

        [TestMethod]
        public void MainViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(ViewType.Main);

            Assert.IsInstanceOfType(viewModel, typeof(MainViewModel));
        }

        [TestMethod]
        public void NewEntryViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(ViewType.New);

            Assert.IsInstanceOfType(viewModel, typeof(NewEntryViewModel));
        }

        [TestMethod]
        public void DetailViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(ViewType.Detail);

            Assert.IsInstanceOfType(viewModel, typeof(DetailViewModel));
        }
    }
}
