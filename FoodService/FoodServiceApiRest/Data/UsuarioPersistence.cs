using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Data
{
    public class UsuarioPersistence
    {
        private SqlConnection conn = new SqlConnection();

        public UsuarioPersistence()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConexionGenius"].ConnectionString;
            conn.ConnectionString = strConnString;
            conn.Open();
        }

        public UsuarioModel Get(LoginModel login)
        {
            var obj = new UsuarioModel();
            try
            {
                string sqlString = "Select idEmpleado, UserName,Nombre,Cedula,Isnull(EsAdministrador,0) EsAdministrador, Isnull(EsSuperUsuario,0) EsSuperUsuario, IdArea from Empleado where username = '" + login.UserName + "' and cedula = '" + login.PassWord + "'" ;
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.Id = (int)reader["idEmpleado"];
                    obj.UserName = (string)reader["UserName"];
                    obj.UserFullName = (string)reader["Nombre"];
                    obj.Password = (string)reader["Cedula"];
                    obj.EsAdministrador = (bool)reader["EsAdministrador"];
                    obj.EsSuperUsuario = (bool)reader["EsSuperUsuario"];
                    obj.IdArea = (int)reader["idArea"];
                }
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null; // return the list
        }
    }
}