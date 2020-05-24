using FoodServiceApiRest.Data;
using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodServiceApiRest.Controllers
{
    public class AreaController : ApiController
    {
        AreaPersistence ap = new AreaPersistence();
        // GET: api/Area
        public IEnumerable<AreaModel> Get()
        {
            var areas = ap.GetAll();
            return areas.ToList();
        }

        // GET: api/Area/5
        public AreaModel Get(int id)
        {
            var area = ap.GetArea(id);
            return area;
        }

        // POST: api/Area
        public HttpResponseMessage Post([FromBody]AreaModel value)
        {
            if (ap.AddArea(value))
            {
                var message = Request.CreateResponse(HttpStatusCode.OK);
                //message.Headers.Location = new Uri(Request.RequestUri + value.Id.ToString());
                return message;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro no ingresado");
        }

        // PUT: api/Area/5
        public HttpResponseMessage Put(int id, [FromBody]AreaModel value)
        {

            if (ap.UpdateArea(value))
            {
                var message = Request.CreateResponse(HttpStatusCode.OK);
                //message.Headers.Location = new Uri(Request.RequestUri + value.Id.ToString());
                return message;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro no actualizado");
        }

        // DELETE: api/Area/5
        public HttpResponseMessage Delete(int id)
        {
            if (ap.Delete(id))
            {
                var message = Request.CreateResponse(HttpStatusCode.OK);
                //message.Headers.Location = new Uri(Request.RequestUri + value.Id.ToString());
                return message;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro no eliminado");
        }
    }
}
