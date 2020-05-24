using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Models
{
    public class NovedadModel
    {
        public long Id { get; set; }
        public long IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public bool NoAlimentacion { get; set; }
        public string Notas { get; set; }
        public DateTime FechaIng { get; set; }
        public string UsuarioIng { get; set; }
        public long idTurnoDetalle { get; set; }
        public long idPlato { get; set; }
    }
}