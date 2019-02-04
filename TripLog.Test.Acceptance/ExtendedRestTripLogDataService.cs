namespace TripLog.Test.Acceptance
{
    using Models;
    using Services;

    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ExtendedRestTripLogDataService : RestTripLogDataService
    {
        public ExtendedRestTripLogDataService(
            StandardAsyncHttpClient httpClient, 
            Uri baseUri)
            : base(httpClient, baseUri)
        { }

        public async Task RemoveAll()
        {
            var response = await HttpClient.SendRequestAsync<TripLogEntry>(BaseUri, HttpMethod.Delete, Headers);
        }
    }
}
