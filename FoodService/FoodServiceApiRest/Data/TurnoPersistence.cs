using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Data
{
    public class TurnoPersistence
    {
        private SqlConnection conn = new SqlConnection();

        public TurnoPersistence()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConexionGenius"].ConnectionString;
            conn.ConnectionString = strConnString;
            conn.Open();
        }

        public List<TurnoModel> GetAll()
        {
            List<TurnoModel> list = new List<TurnoModel>();
            try
            {
                string sqlString = "Select * from View_TurnosDefault";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new TurnoModel();
                    obj.Id = (int)reader["IdTurnoDetalle"];
                    obj.IdPlato = (int)reader["IdPlato"];
                    obj.Descripcion = (string)reader["Descripcion"] + '(' + reader["Plato"] + ")";
                    obj.Plato = (string)reader["Plato"];
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null; // return the list
        }
    }
}