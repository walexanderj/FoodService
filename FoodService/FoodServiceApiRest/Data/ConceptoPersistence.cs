using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Data
{
    public class ConceptoPersistence
    {
        private SqlConnection conn = new SqlConnection();

        public ConceptoPersistence()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConexionGenius"].ConnectionString;
            conn.ConnectionString = strConnString;
            conn.Open();
        }

        public List<ConceptoModel> GetAll()
        {
            List<ConceptoModel> list = new List<ConceptoModel>();
            try
            {
                string sqlString = "Select * from Concepto";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new ConceptoModel();
                    obj.Id = (int)reader["IdConcepto"];
                    obj.Descripcion = (string)reader["Descripcion"];
                    obj.Uso = (string)reader["Uso"];
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