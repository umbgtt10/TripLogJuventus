namespace TripLog.Server.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Http;

    using TripLog.Models;

    public class TripLogWebController : ApiController
    {
        private TripLogPersistency _persistency;
        private Environment _environment;

        public TripLogWebController()
        {
            _environment = Environment.Test;
            _persistency = new TripLogPersistencyBuilder(new DirectoryInfo(@"C:\WebServer\Persistency")).
                Build(_environment);
            _persistency.Setup();
        }

        // GET api/TripLogWeb
        public IEnumerable<TripLogEntry> Get()
        {
            var results = _persistency.GetAll();

            _persistency.Dispose();

            return results;
        }

        // POST api/TripLogWeb
        public void Post([FromBody]TripLogEntry value)
        {
            _persistency.Add(value);

            _persistency.Dispose();
        }

        // GET api/TripLogWeb/5
        public string Get(int id)
        {
            return "value"; // or exception
        }

        // PUT api/TripLogWeb/5
        public void Put(int id, [FromBody]string value)
        {
            // Nothing or exception?
        }

        // DELETE api/TripLogWeb/5
        public void Delete(int id)
        {
            // Nothing or exception?
        }

        public void Delete()
        {
            if (_environment == Environment.Test)
            {
                ((ExtendedDbreezeTripLogPersistency)_persistency).RemoveAll();

                _persistency.Dispose();
            }
            else
            {
                // Nothing or exception?
            }
        }
    }
}
