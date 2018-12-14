namespace TripLog.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TripLog.Models;
    using TripLog.ViewModels;
    using TripLog.Views;

    [TestClass]
    public class ViewFactoryTests
    {           
        [TestMethod]
        public void MainViewCreationTest()
        {
            var viewModel = TestInit.ViewModelFactory.Build(ViewType.Main);
            viewModel.Init();
            var view = TestInit.ViewFactory.Build(ViewType.Main, viewModel);

            Assert.IsInstanceOfType(view, typeof(MainPage));
        }

        [Ignore]
        [TestMethod]
        public void NewEntryViewCreationTest()
        {
            var viewModel = TestInit.ViewModelFactory.Build(ViewType.New);
            viewModel.Init();
            var view = TestInit.ViewFactory.Build(ViewType.New, viewModel);

            Assert.IsInstanceOfType(view, typeof(NewEntryPage));
        }

        [TestMethod]
        public void DetailViewModelCreationTest()
        {
            var entry = new TripLogEntry()
            {
                Title = "Title"
            };

            var viewModel = TestInit.ViewModelFactory.Build(ViewType.Detail);
            viewModel.Init(entry);
            var view = TestInit.ViewFactory.Build(ViewType.Detail, viewModel);

            Assert.IsInstanceOfType(view, typeof(DetailPage));
        }
    }
}
