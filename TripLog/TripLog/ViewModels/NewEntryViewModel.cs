namespace TripLog.ViewModels
{
    using System;

    using Xamarin.Forms;

    using Models;
    using Services;

    public class NewEntryViewModel : BaseViewModel
    {
        #region Observables

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; OnPropertyChanged(); }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; OnPropertyChanged(); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; OnPropertyChanged(); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands
        private Command _saveCommand;
        public Command SaveCommand
        {
            get
                
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(ExecuteSaveCommand, CanSave);
                }
                return _saveCommand;
            }
        }

        private bool CanSave(object arg)
        {
            return !string.IsNullOrEmpty(Title);
        }

        private async void ExecuteSaveCommand(object obj)
        {
            var newEntry = new TripLogEntry
            {
                Title = Title,
                Notes = Notes,
                Rating = Rating,
                Date = Date,
                Latitude = Latitude,
                Longitude = Longitude
            };

            await _tripLogDataService.AddEntryAsync(newEntry);
        }

        #endregion

        private readonly GeoLocationService _locationService;
        private readonly TripLogDataService _tripLogDataService;

        public NewEntryViewModel(GeoLocationService locationService, TripLogDataService tripLogDataService)
        {
            _locationService = locationService;
            _tripLogDataService = tripLogDataService;
        }

        public override async void Init()
        {
            Date = DateTime.Today;
            Rating = 1;

            var coords = await _locationService.PullCoordinatesAsync();

            Longitude = coords.Longitude;
            Latitude = coords.Latitude;
        }

        public override void Init(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
