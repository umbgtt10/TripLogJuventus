using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.ViewModels;

namespace TripLog.Test
{
    [TestClass]
    public class ViewModelFactoryTests
    {
        private static ViewModelFactory ViewModelFactory = new ViewModelFactory();

        [TestMethod]
        public void MainViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(TripLogViewModelType.Main);

            Assert.IsInstanceOfType(viewModel, typeof(MainViewModel));
        }

        [TestMethod]
        public void NewEntryViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(TripLogViewModelType.New);

            Assert.IsInstanceOfType(viewModel, typeof(NewEntryViewModel));
        }

        [TestMethod]
        public void DetailViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(TripLogViewModelType.Detail);

            Assert.IsInstanceOfType(viewModel, typeof(DetailViewModel));
        }
    }
}
