using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripLog.Models;

namespace TripLog.Server.Controllers
{
    public class TripLogWebController : ApiController
    {
        private TripLogPersistency _persistency;

        public TripLogWebController()
        {
            _persistency = new DbreezeTripLogPersistency(new DirectoryInfo(@"C:\WebServer\Persistency"));
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
            return "value";
        }

        // PUT api/TripLogWeb/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/TripLogWeb/5
        public void Delete(int id)
        {
        }
    }
}
