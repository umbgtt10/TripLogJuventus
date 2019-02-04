﻿namespace TripLog.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Models;

    public class RestTripLogDataService : TripLogDataService
    {
        protected readonly StandardAsyncHttpClient HttpClient;
        protected readonly Uri BaseUri;
        protected readonly IDictionary<string, string> Headers;

        public RestTripLogDataService(StandardAsyncHttpClient httpClient, Uri baseUri)
        {
            HttpClient = httpClient;
            BaseUri = baseUri;
            Headers = new Dictionary<string, string>();
        }

        public async Task AddEntryAsync(TripLogEntry entry)
        {
            var response = await HttpClient.SendRequestAsync<TripLogEntry>(BaseUri, HttpMethod.Post, Headers, entry);            
        }

        public async Task<IList<TripLogEntry>> ReadAllEntriesAsync()
        {
            var response = await HttpClient.SendRequestAsync<TripLogEntry[]>(BaseUri, HttpMethod.Get, Headers);
            return response;
        }
    }
}
   