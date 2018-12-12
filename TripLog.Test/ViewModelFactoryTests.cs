using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.ViewModels;

namespace TripLog.Test
{
    [TestClass]
    public class ViewModelFactoryTests
    {
        [TestMethod]
        public void TestMainViewModelFactoryCreation()
        {
            var viewModelFactory = new ViewModelFactory();

            var instance = viewModelFactory.Build(TripLogViewModelType.Main);

            Assert.IsTrue(instance is MainViewModel);
        }

        [TestMethod]
        public void TestDetailViewModelFactoryCreation()
        {
            var viewModelFactory = new ViewModelFactory();

            var instance = viewModelFactory.Build(TripLogViewModelType.Detail);

            Assert.IsTrue(instance is DetailViewModel);
        }

        [TestMethod]
        public void TestNewEntryViewModelFactoryCreation()
        {
            var viewModelFactory = new ViewModelFactory();

            var instance = viewModelFactory.Build(TripLogViewModelType.New);

            Assert.IsTrue(instance is NewEntryViewModel);
        }
    }
}
