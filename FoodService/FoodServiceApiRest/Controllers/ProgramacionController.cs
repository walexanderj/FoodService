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
    public class ProgramacionController : ApiController
    {
        ProgramacionPersistence pp = new ProgramacionPersistence();
        // GET: api/Programacion
        public IEnumerable<ProgramacionModel> Get()
        {
            var programacion = pp.Get();
            return programacion;
        }

        // GET: api/Programacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Programacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Programacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Programacion/5
        public void Delete(int id)
        {
        }
    }
}
