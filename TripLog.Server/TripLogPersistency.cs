using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripLog.Models;

namespace TripLog.Server
{
    public interface TripLogPersistency : IDisposable
    {
        void Setup();
        IEnumerable<TripLogEntry> GetAll();
        void Add(TripLogEntry value);
    }
}