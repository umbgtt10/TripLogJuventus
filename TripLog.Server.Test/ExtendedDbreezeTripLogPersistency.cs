using System.IO;

namespace TripLog.Server.Test
{
    public class ExtendedDbreezeTripLogPersistency : DbreezeTripLogPersistency
    {
        public ExtendedDbreezeTripLogPersistency(DirectoryInfo directory) : base(directory)
        {
        }

        public void RemoveAll()
        {
            using (var transaction = _db.GetTransaction())
            {
                transaction.RemoveAllKeys(_tableName, true);
                transaction.Commit();
            }
        }
    }
}

