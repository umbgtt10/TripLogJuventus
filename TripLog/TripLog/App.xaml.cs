using Ninject;
using Ninject.Modules;
using System;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TripLog
{
    public partial class App : Application
    {
        private ViewModelFactory _viewModelFactory;
        private ViewFactory _viewFactory;
        private CombinedFactory _combinedFactory;
        private IKernel _kernel;

        public App(params NinjectModule[] platformModules)
        {
            InitializeComponent();

            _kernel = new StandardKernel();
            _kernel.Load(platformModules);

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

            MainPage = new NavigationPage(mainPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
