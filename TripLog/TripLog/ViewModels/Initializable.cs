using TripLog.Models;

namespace TripLog.ViewModels
{
    public interface Initializable
    {
        void Init();
        void Init(TripLogEntry entry);
    }
}
