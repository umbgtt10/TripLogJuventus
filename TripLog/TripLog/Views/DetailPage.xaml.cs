using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{

        private DetailViewModel _vm
        {
            get
            {
                return BindingContext as DetailViewModel;
            }
        }

        public DetailPage (TripLogEntry entry)
		{
			InitializeComponent();

            BindingContext = new DetailViewModel(entry);

            var position = new Position(_vm.Entry.Latitude, _vm.Entry.Longitude);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = entry.Title,
                Position = position
            });

            //title.Text = entry.Title;
            //date.Text = entry.Date.ToString("M");
            //rating.Text = $"{entry.Rating} star rating";
            //notes.Text = entry.Notes;
        }
	}
}