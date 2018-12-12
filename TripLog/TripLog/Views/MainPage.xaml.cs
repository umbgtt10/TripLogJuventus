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
        public MainPage(BaseViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        public void New_Clicked(object sender, EventArgs e)
        {
            var viewModel = new NewEntryViewModel();
            viewModel.Init();

            var newEntryPage = new NewEntryPage(viewModel);

            Navigation.PushAsync(newEntryPage);
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;

            var viewModel = new DetailViewModel();
            viewModel.Init(trip);

            var detailPage = new DetailPage(viewModel);

            await Navigation.PushAsync(detailPage);

            // Clear selection
            trips.SelectedItem = null;
        }
    }
}
