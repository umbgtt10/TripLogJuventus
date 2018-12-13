using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TripLog.Server.Controllers
{
    public class TripLogWebController : ApiController
    {
        // GET api/TripLogWeb
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/TripLogWeb/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/TripLogWeb
        public void Post([FromBody]string value)
        {
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
