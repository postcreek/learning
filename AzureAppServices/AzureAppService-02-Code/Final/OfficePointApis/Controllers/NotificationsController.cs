using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OfficePointApis.Controllers
{
     
    public class NotificationsController : ApiController
    {
        // GET: api/Notifications
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        public async Task<IHttpActionResult> Post(string displayName)
        {
            await Helpers.ToastHelper.SendPhoneCall(displayName);

            return StatusCode(HttpStatusCode.Created);
        } 

        // PUT: api/Notifications/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Notifications/5
        public void Delete(int id)
        {
        }
    }
}
