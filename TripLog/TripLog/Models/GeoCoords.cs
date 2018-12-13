﻿namespace TripLog.Models
{
    public class GeoCoords
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoords()
        {
            Latitude = 0;
            Longitude = 0;
        }
    }
}
