using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TripLog.Models;
using TripLog.ViewModels;

namespace TripLog.Test
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void MainViewModelInitializationThrowsTest()
        {
            var viewModel = new MainViewModel();

            var entry = new TripLogEntry();

            viewModel.Init(entry);        
        }

        [TestMethod]
        public void MainViewModelInitializationOkTest()
        {
            var viewModel = new MainViewModel();

            viewModel.Init();

            Assert.AreEqual(3, viewModel.LogEntries.Count);
        }

        [TestMethod]
        public void DetailViewModelInitializationThrowsTest()
        {
            var viewModel = new DetailViewModel();

            var entry = new TripLogEntry();

            viewModel.Init(entry);

            Assert.AreEqual(entry, viewModel.Entry);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DetailViewModelInitializationOkTest()
        {
            var viewModel = new DetailViewModel();

            viewModel.Init();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void NewEntryViewModelInitializationThrowsTest()
        {
            var viewModel = new NewEntryViewModel();

            var entry = new TripLogEntry();

            viewModel.Init(entry);
        }

        [TestMethod]        
        public void NewEntryViewModelInitializationOkTest()
        {
            var viewModel = new NewEntryViewModel();

            viewModel.Init();

            Assert.AreEqual(1, viewModel.Rating);
        }
    }
}
