namespace TripLog.Models
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

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

            TripLogEntry result = new TripLogEntry
            {
                Id = entry.Id,
                Title = entry.Title,
                Latitude = entry.Latitude,
                Longitude = entry.Longitude,
                Date = entry.Date,
                Rating = entry.Rating,
                Notes = entry.Notes
            };

            return result;
        }

        public static string Serialize(TripLogEntry entry)
        {
            return JsonConvert.SerializeObject(entry);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TripLogEntry))
            {
                return false;
            }

            var instance = (TripLogEntry)obj;

            return instance.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }
    }
}
