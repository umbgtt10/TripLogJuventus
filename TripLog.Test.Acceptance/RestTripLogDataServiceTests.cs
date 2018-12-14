using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.Test.Acceptance
{
    [TestClass]
    public class RestTripLogDataServiceTests
    {
        public static TripLogEntry First = new TripLogEntry("First");
        public static TripLogEntry Second = new TripLogEntry("Second");

        private ExtendedRestTripLogDataService _client;
        private Uri _url;

        [TestInitialize]
        public async Task Setup()
        {
            _url = new Uri("http://localhost:20080/api/TripLogWeb/");
            var httpClient = new StandardAsyncHttpClient();
            _client = new ExtendedRestTripLogDataService(httpClient, _url);
            await SetBaseLine();
        }

        [TestCleanup]
        public async Task ShutDown()
        {
            await SetBaseLine();
        }

        private async Task SetBaseLine()
        {
            if (_client != null)
            {
                await _client.RemoveAll();
            }
        }

        [TestMethod]
        public async Task SimpleInsertRetrieveTest()
        {
            await _client.AddEntryAsync(First);

            var retrieved = await _client.ReadAllEntriesAsync();

            Assert.AreEqual(1, retrieved.Count);
            Assert.AreEqual(First, retrieved.First());
        }

        [TestMethod]
        public async Task RemoveAllTest()
        {
            await _client.RemoveAll();

            var retrieved = await _client.ReadAllEntriesAsync();

            Assert.AreEqual(0, retrieved.Count);
        }
    }
}
