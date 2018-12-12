using System;
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

        public App()
        {
            InitializeComponent();

            _viewModelFactory = new ViewModelFactory();
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
