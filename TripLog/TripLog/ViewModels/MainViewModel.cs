﻿namespace TripLog.ViewModels
{
    using System;
    using System.Collections.ObjectModel;

    using Models;
    using Services;

    public class MainViewModel : BaseViewModel
    {
        #region Observables

        private ObservableCollection<TripLogEntry> _logEntries;
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get
            { return _logEntries; }

            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private readonly TripLogDataService _tripLogDataService;

        public MainViewModel(TripLogDataService tripLogDataService)
        {
            _tripLogDataService = tripLogDataService;            
        }

        public override async void Init()
        {
            LogEntries = new ObservableCollection<TripLogEntry>(
              await _tripLogDataService.ReadAllEntriesAsync());

            var item1 = new TripLogEntry
            {
                Title = "Washington Monument",
                Notes = "Amazing!",
                Rating = 3,
                Date = new DateTime(2017, 2, 5),
                Latitude = 38.8895,
                Longitude = -77.0352
            };
            var item2 = new TripLogEntry
            {
                Title = "Statue of Liberty",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2017, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            };
            var item3 = new TripLogEntry
            {
                Title = "Golden Gate Bridge",
                Notes = "Foggy, but beautiful.",
                Rating = 5,
                Date = new DateTime(2017, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            };

            LogEntries.Add(item1);
            LogEntries.Add(item2);
            LogEntries.Add(item3);                        
        }

        public override void Init(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
