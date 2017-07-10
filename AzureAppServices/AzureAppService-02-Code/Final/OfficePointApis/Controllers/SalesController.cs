using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfficePointApis.Controllers
{
    
    public class SalesController : ApiController
    {
       

        public HttpResponseMessage Get()
        {
            var imageBytes = Helpers.SalesHelper.BuildSalesChart();

            HttpResponseMessage response = new HttpResponseMessage { Content = new ByteArrayContent(imageBytes) };
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            response.Content.Headers.ContentLength = imageBytes.Length;
            return response;
        }

        // POST: api/Sales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sales/5
        public void Delete(int id)
        {
        }
    }
}
