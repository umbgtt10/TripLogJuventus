using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.Models;
using TripLog.ViewModels;
using TripLog.Views;

namespace TripLog.Test
{
    [TestClass]
    public class ViewFactoryTests
    {
        private static ViewFactory ViewFactory = new ViewFactory(ViewModelFactoryTests.ViewModelFactory);

        [TestMethod]
        public void MainViewCreationTest()
        {
            var viewModel = ViewModelFactoryTests.ViewModelFactory.Build(ViewType.Main);
            viewModel.Init();
            var view = ViewFactory.Build(ViewType.Main, viewModel);

            Assert.IsInstanceOfType(view, typeof(MainPage));
        }

        [Ignore]
        [TestMethod]
        public void NewEntryViewCreationTest()
        {
            var viewModel = ViewModelFactoryTests.ViewModelFactory.Build(ViewType.New);
            viewModel.Init();
            var view = ViewFactory.Build(ViewType.New, viewModel);

            Assert.IsInstanceOfType(view, typeof(NewEntryPage));
        }

        [TestMethod]
        public void DetailViewModelCreationTest()
        {
            var entry = new TripLogEntry()
            {
                Title = "Title"
            };

            var viewModel = ViewModelFactoryTests.ViewModelFactory.Build(ViewType.Detail);
            viewModel.Init(entry);
            var view = ViewFactory.Build(ViewType.Detail, viewModel);

            Assert.IsInstanceOfType(view, typeof(DetailPage));
        }
    }
}
