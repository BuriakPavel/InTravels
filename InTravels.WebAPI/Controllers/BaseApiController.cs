using InTravels.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace InTravels.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseApiController : ApiController
    {
        [HttpGet]
        [Route("api/Base/CheckApi")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public IHttpActionResult CheckApi()
        {
            return Ok();
        }
    }
}
