using DBreeze;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TripLog.Models;

namespace TripLog.Server
{
    public class DbreezeTripLogPersistency : TripLogPersistency
    {
        protected string _tableName = "TripLogTable";

        protected DBreezeEngine _db;
        protected DirectoryInfo _dbDirectory;

        public DbreezeTripLogPersistency(DirectoryInfo directory)
        {
            _dbDirectory = directory;
            _db = new DBreezeEngine(directory.FullName);
        }

        public void Setup()
        {
            if (!_dbDirectory.Exists)
            {
                _dbDirectory.Create();
            }
        }

        public void Add(TripLogEntry value)
        {
            using (var transaction = _db.GetTransaction())
            {
                transaction.Insert(_tableName, value.Id, TripLogEntry.Serialize(value));
                transaction.Commit();
            }
        }

        public IEnumerable<TripLogEntry> GetAll()
        {
            IList<TripLogEntry> result;

            using (var transaction = _db.GetTransaction())
            {
                var select = transaction.SelectForward<string, string>(_tableName);
                result = select.Select(elem => TripLogEntry.Deserialize(elem.Value)).ToList();
                transaction.Commit();
            }

            return result;
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}