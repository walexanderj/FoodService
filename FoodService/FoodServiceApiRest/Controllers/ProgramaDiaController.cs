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
    public class ProgramaDiaController : ApiController
    {
        ProgramacionPersistence pp = new ProgramacionPersistence();
        //// GET: api/ProgramaDia
        //public IEnumerable<ProgramaDiaModel> Get(DateTime fechaInicio)
        //{
        //    var programaDia = pp.ProgramaDia(fechaInicio, fechaInicio);
        //    return programaDia.ToList();
        //}
        // GET: api/ProgramaDia
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ProgramaDia/5
        public IEnumerable<ProgramaDiaModel> Get(string id)
        {
            
            DateTime F = new DateTime();
            try
            {
                 F = Convert.ToDateTime(id.ToString().Substring(0,4) + "-" + id.ToString().Substring(4,2) + "-" + id.ToString().Substring(6, 2));
            }
            catch (Exception)
            {
                F = DateTime.Now;
            }
           
            var programaDia = pp.ProgramaDia(F, F);
            return programaDia.ToList();
        }

        //// POST: api/ProgramaDia
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/ProgramaDia/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ProgramaDia/5
        //public void Delete(int id)
        //{
        //}
    }
}
