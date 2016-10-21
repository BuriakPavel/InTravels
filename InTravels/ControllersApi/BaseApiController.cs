using InTravels.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InTravels.ControllersApi
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class BaseApiController : ApiController
    {

	}
}
