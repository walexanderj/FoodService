using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Models
{
    public class ConceptoModel
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string Uso { get; set; }
    }
}