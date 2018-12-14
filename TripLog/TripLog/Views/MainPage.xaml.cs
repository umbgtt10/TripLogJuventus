namespace TripLog.Views
{
    using System;

    using Xamarin.Forms;

    using TripLog.Models;
    using TripLog.ViewModels;

    public partial class MainPage : ContentPage
    {
        private CombinedFactory _combinedFactory;
        private BaseViewModel _vm;

        public MainPage(BaseViewModel viewModel)
        {
            InitializeComponent();
            _vm = viewModel;
            BindingContext = _vm;
        }

        public void Init(CombinedFactory combinedFactory)
        {
            _combinedFactory = combinedFactory;
        }

        public void New_Clicked(object sender, EventArgs e)
        {
            var newEntryPage = _combinedFactory.Build(ViewType.New);

            Navigation.PushAsync(newEntryPage);
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;

            var detailPage = _combinedFactory.Build(ViewType.Detail, trip);

            await Navigation.PushAsync(detailPage);

            trips.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            _vm.Init();
        }
    }
}
