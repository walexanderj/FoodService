using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Models
{
    public class TurnoModel
    {
        public long Id { get; set; }
        public int IdPlato { get; set; }
        public string Descripcion { get; set; }
        public string Plato { get; set; }
    }
}