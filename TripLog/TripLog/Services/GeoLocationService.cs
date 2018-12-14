namespace TripLog.Services
{
    using System.Threading.Tasks;

    using TripLog.Models;

    public interface GeoLocationService
    {
        Task<GeoCoords> PullCoordinatesAsync();
    }
}
   