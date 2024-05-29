using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class CiudadController : ApiController
    {
        [Route("api/Ciudades/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = BL.Ciudad.GetAll();
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result.Item3);
            }
            else
            {
                return Content(HttpStatusCode.OK, result.Item2);
            }
        }
    }
}
