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
        private CombinedFactory _combinedFactory;

        public MainPage(BaseViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
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

            // Clear selection
            trips.SelectedItem = null;
        }
    }
}
