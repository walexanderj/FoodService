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
    public class NovedadController : ApiController
    {
        NovedadPersistence np = new NovedadPersistence();
        // POST: api/Area
        public HttpResponseMessage Post([FromBody]NovedadModel value)
        {
            if (np.AddNovedad(value))
            {
                var message = Request.CreateResponse(HttpStatusCode.OK);
                //message.Headers.Location = new Uri(Request.RequestUri + value.Id.ToString());
                return message;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Registro no ingresado");
        }

    }
}
