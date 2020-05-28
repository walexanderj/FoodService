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
        public IEnumerable<ProgramaDiaModel> GetProgramaDia(DateTime fechaInicio, DateTime fechaFinal)
        {
            var programaDia = pp.ProgramaDia(fechaInicio, fechaFinal);
            return programaDia.ToList();
        }


    }
}
