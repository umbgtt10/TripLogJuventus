using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripLog.Models
{
    public class TripLogEntry
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }

        public TripLogEntry(string title) : this()
        {
            Title = title;
        }

        public TripLogEntry()
        {
            Title = string.Empty;
            Id = Guid.NewGuid().ToString();
            Notes = string.Empty;
        }

        public static TripLogEntry Deserialize(string serializedTripLogEntry)
        {
            var entry = JsonConvert.DeserializeObject<TripLogEntry>(serializedTripLogEntry);

            TripLogEntry result = new TripLogEntry();

            result.Id = entry.Id;
            result.Title = entry.Title;
            result.Latitude = entry.Latitude;
            result.Longitude = entry.Longitude;
            result.Date = entry.Date;
            result.Rating = entry.Rating;
            result.Notes = entry.Notes;

            return result;
        }

        public static string Serialize(TripLogEntry entry)
        {
            return JsonConvert.SerializeObject(entry);
        }
    }
}
