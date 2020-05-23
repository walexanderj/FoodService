using FoodServiceApiRest.Models;
using FoodServiceApiRest.app_code;
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
        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
            UsuarioPersistence up = new UsuarioPersistence();
            UsuarioModel usuario = new UsuarioModel();
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
