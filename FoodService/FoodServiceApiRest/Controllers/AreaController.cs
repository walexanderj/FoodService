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
        // GET: api/Area
        public IEnumerable<AreaModel> Get()
        {
            AreaPersistence ap = new AreaPersistence();
            var areas = ap.GetAll();
            return areas.ToList();
        }

        // GET: api/Area/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Area
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Area/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Area/5
        public void Delete(int id)
        {
        }
    }
}
