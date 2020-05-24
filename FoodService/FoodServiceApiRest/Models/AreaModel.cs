using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Models
{
    public class AreaModel
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public bool ProgramarTurnos { get; set; }
        public bool CambiosEnPeriodo { get; set; }
        public string Email { get; set; }
        public List<EmpleadoModel> Empleados { get; set; }
    }
}