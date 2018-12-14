namespace TripLog.ViewModels
{
    using System;

    using TripLog.Services;

    public class ViewModelFactory
    {
        private GeoLocationService _locationService;
        private TripLogDataService _tripLogDataSevice;

        public ViewModelFactory(GeoLocationService locationService, TripLogDataService tripLogDataSevice)
        {
            _locationService = locationService;
            _tripLogDataSevice = tripLogDataSevice;
        }

        public BaseViewModel Build(ViewType viewModelType)
        {
            switch(viewModelType)
            {
                case ViewType.Detail:
                    return new DetailViewModel();
                case ViewType.Main:
                    return new MainViewModel(_tripLogDataSevice);
                case ViewType.New:
                    return new NewEntryViewModel(_locationService, _tripLogDataSevice);
                default:
                    throw new Exception($"Unknown {viewModelType}");
            }
        }
    }
}
