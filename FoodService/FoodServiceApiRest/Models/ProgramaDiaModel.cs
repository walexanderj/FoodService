using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Models
{
    public class ProgramaDiaModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Dia { get; set; }
        public string Plato { get; set; }
        public int Cantidad { get; set; }
        public string HoraPrograma { get; set; }
    }
}