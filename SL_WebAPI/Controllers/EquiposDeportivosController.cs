using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace SL_WebAPI.Controllers
{
    public class EquiposDeportivosController : ApiController
    {
        [Route("api/EquiposDeportivos/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = BL.EquiposDeportivos.GetAll();
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.OK, result);
            }
        }

        [Route("api/EquiposDeportivos/GetById")]
        [HttpGet]
        public IHttpActionResult GetById(int IdEquipo)
        {
            var result = BL.EquiposDeportivos.GetById(IdEquipo);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.OK, result);
            }
        }


        [Route("api/EquiposDeportivos/Add")]
        [HttpPost]
        public IHttpActionResult Add(ML.EquiposDeportivos equiposDeportivos)
        {
            var result = BL.EquiposDeportivos.Add(equiposDeportivos);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, new { HttpMessageContent = "El equipo se registro correctamente" });
            }
            else
            {
                return Content(HttpStatusCode.OK, new { HttpMessageContent = "El equipo no se registro" + result.Item3 });
            }
        }


        [Route("api/EquiposDeportivos/Update")]
        [HttpPut]
        public IHttpActionResult Update(ML.EquiposDeportivos equiposDeportivos)
        {
            var result = BL.EquiposDeportivos.Update(equiposDeportivos);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, new { HttpMessageContent = "El equipo se actualizo correctamente" });
            }
            else
            {
                return Content(HttpStatusCode.OK, new { HttpMessageContent = "El equipo no se actualizo" + result.Item3 });
            }
        }

        [Route("api/EquiposDeportivos/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int? IdEquipo)
        {
            var result = BL.EquiposDeportivos.Delete(IdEquipo);

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

    }
}

