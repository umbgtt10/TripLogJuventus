using System;
using System.Collections.Generic;
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
            _persistency = new DbreezeTripLogPersistency();
        }

        // GET api/TripLogWeb
        public IEnumerable<TripLogEntry> Get()
        {
            return _persistency.GetAll();
        }

        // POST api/TripLogWeb
        public void Post([FromBody]TripLogEntry value)
        {
            _persistency.Add(value);
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
