using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodServiceApiRest.Data;

namespace FoodServiceApiRest.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioPersistence up = new UsuarioPersistence();

        // POST api/Login
        [Route("api/Login")]
        public UsuarioModel Post([FromBody]LoginModel value)
        {
            UsuarioModel user = new UsuarioModel();
            user = up.Get(value);
           
            if (user!=null)
            {
                var message = Request.CreateResponse(HttpStatusCode.OK);
                //message.Headers.Location = new Uri(Request.RequestUri + value.Id.ToString());
                return user;
            }
            return new UsuarioModel();
        }

    }
}
