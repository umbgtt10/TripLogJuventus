using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		public DetailPage (TripLogEntry entry)
		{
			InitializeComponent();

            var position = new Position(entry.Latitude, entry.Longitude);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = entry.Title,
                Position = position
            });

            title.Text = entry.Title;
            date.Text = entry.Date.ToString("M");
            rating.Text = $"{entry.Rating} star rating";
            notes.Text = entry.Notes;
        }
	}
}