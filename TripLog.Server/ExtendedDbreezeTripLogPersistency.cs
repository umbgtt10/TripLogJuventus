﻿namespace TripLog.Server
{
    using System.IO;

    public class ExtendedDbreezeTripLogPersistency : DbreezeTripLogPersistency
    {
        public ExtendedDbreezeTripLogPersistency(DirectoryInfo directory) : base(directory)
        {
        }

        public void RemoveAll()
        {
            using (var transaction = Db.GetTransaction())
            {
                transaction.RemoveAllKeys(TableName, true);
                transaction.Commit();
            }
        }
    }
}

