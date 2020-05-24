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
    public class EmpleadoController : ApiController
    {

        EmpleadoPersistence ep = new EmpleadoPersistence();
        // GET: api/Empleado
        public IEnumerable<EmpleadoModel> Get()
        {
            var empleados = ep.GetAll();
            return empleados.ToList();
        }

        // GET: api/Empleado/5
        public EmpleadoModel Get(int id)
        {
            var area = ep.Get(id);
            return area;
        }

    }
}
