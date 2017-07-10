﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfficePointApis.Controllers
{
     
    public class FactsController : ApiController
    {
        // GET: api/Facts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [Route("api/Facts/GetRandom")]
        public Fact GetRandom()
        {
            return Helpers.FactHelper.GetRandomFact();
        }

        // POST: api/Facts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Facts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Facts/5
        public void Delete(int id)
        {
        }
    }
}
