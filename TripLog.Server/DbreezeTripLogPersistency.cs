namespace TripLog.Server
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using DBreeze;

    using TripLog.Models;

    public class DbreezeTripLogPersistency : TripLogPersistency
    {
        protected string TableName = "TripLogTable";

        protected DBreezeEngine Db;
        protected DirectoryInfo DbDirectory;

        public DbreezeTripLogPersistency(DirectoryInfo directory)
        {
            DbDirectory = directory;
            Db = new DBreezeEngine(directory.FullName);
        }

        public void Setup()
        {
            if (!DbDirectory.Exists)
            {
                DbDirectory.Create();
            }
        }

        public void Add(TripLogEntry value)
        {
            using (var transaction = Db.GetTransaction())
            {
                transaction.Insert(TableName, value.Id, TripLogEntry.Serialize(value));
                transaction.Commit();
            }
        }

        public IEnumerable<TripLogEntry> GetAll()
        {
            IList<TripLogEntry> result;

            using (var transaction = Db.GetTransaction())
            {
                var select = transaction.SelectForward<string, string>(TableName);
                result = select.Select(elem => TripLogEntry.Deserialize(elem.Value)).ToList();
                transaction.Commit();
            }

            return result;
        }

        public void Dispose()
        {
            if (Db != null)
            {
                Db.Dispose();
            }
        }
    }
}