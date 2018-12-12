using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        private ViewModelFactory _viewModelFactory;

        public MainPage(ViewModelFactory viewModelFactory, BaseViewModel viewModel)
        {
            InitializeComponent();

            _viewModelFactory = viewModelFactory;

            BindingContext = viewModel;
        }

        public void New_Clicked(object sender, EventArgs e)
        {
            var viewModel = _viewModelFactory.Build(TripLogViewModelType.New);
            viewModel.Init();

            var newEntryPage = new NewEntryPage(viewModel);

            Navigation.PushAsync(newEntryPage);
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;

            var viewModel = _viewModelFactory.Build(TripLogViewModelType.Detail);
            viewModel.Init(trip);

            var detailPage = new DetailPage(viewModel);

            await Navigation.PushAsync(detailPage);

            // Clear selection
            trips.SelectedItem = null;
        }
    }
}
