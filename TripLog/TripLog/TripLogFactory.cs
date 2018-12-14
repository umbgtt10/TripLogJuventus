namespace TripLog
{
    using System;

    using Ninject;
    using Ninject.Modules;
    using Xamarin.Forms;

    using TripLog.Services;
    using TripLog.ViewModels;
    using TripLog.Views;

    public class TripLogFactory
    {
        private ViewModelFactory _viewModelFactory;
        private ViewFactory _viewFactory;
        private CombinedFactory _combinedFactory;
        private IKernel _kernel;

        public TripLogFactory(params NinjectModule[] platformModules)
        {
            _kernel = new StandardKernel();
            _kernel.Load(platformModules);
        }

        public ContentPage Build()
        {
            var locationService = _kernel.Get<GeoLocationService>();

            var httpClient = new StandardAsyncHttpClient();
            var backendUri = new Uri("http://192.168.56.10:20080/api/TripLogWeb/");
            var restTripLogDataService = new RestTripLogDataService(httpClient, backendUri);
            _viewModelFactory = new ViewModelFactory(locationService, restTripLogDataService);
            _viewFactory = new ViewFactory(_viewModelFactory);
            _combinedFactory = new CombinedFactory(_viewFactory, _viewModelFactory);

            var viewModel = _viewModelFactory.Build(ViewType.Main);
            viewModel.Init();

            var mainPage = new MainPage(viewModel);
            mainPage.Init(_combinedFactory);

            return mainPage;
        }
    }
}
