using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace OfficePointApis.Controllers
{
     
    public class NewsController : ApiController
    {    
        [ResponseType(typeof(List<NewsInformation>))]
        public async Task<IHttpActionResult> Get()
        { 
            var result = await Helpers.NewsHelper.GetTrendingNewsAsync();

            return Ok(result);
        }
         
        // POST: api/News
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/News/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/News/5
        public void Delete(int id)
        {
        }
    }
}
