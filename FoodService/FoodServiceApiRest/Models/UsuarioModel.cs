using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Models
{
    public class UsuarioModel
    {
        long Id { get; set; }
        String UserName { get; set; }
        String UserFullName { get; set; }
        string Password { get; set;}
    }
}