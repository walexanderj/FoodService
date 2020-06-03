using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Models
{
    public class ProgramacionModel
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdEmpleado { get; set; }
        public long IdPlato { get; set; }
        public string Plato { get; set; }
        public int Cantidad { get; set; }
        public long IdTurno { get; set; }
        public string Turno { get; set; }
        public long IdPeriodo { get; set; }
        public long IdArea { get; set; }
    }
}