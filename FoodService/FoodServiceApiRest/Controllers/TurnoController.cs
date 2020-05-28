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
    public class TurnoController : ApiController
    {
        TurnoPersistence tp = new TurnoPersistence();
        // GET: api/Turno
        public IEnumerable<TurnoModel> Get()
        {
            var turnos = tp.GetAll();
            return turnos.ToList();
        }

    }
}
