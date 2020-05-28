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
    public class ConceptosController : ApiController
    {

        ConceptoPersistence cp = new ConceptoPersistence();
        // GET: api/Conceptos
        public IEnumerable<ConceptoModel> Get()
        {
            var turnos = cp.GetAll();
            return turnos.ToList();
        }

        // GET: api/Conceptos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Conceptos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Conceptos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Conceptos/5
        public void Delete(int id)
        {
        }
    }
}
