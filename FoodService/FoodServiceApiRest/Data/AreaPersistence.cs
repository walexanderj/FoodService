using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Data
{
    public class AreaPersistence
    {
        private SqlConnection conn = new SqlConnection();
        
        public AreaPersistence()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConexionGenius"].ConnectionString;
            conn.ConnectionString = strConnString;
            conn.Open();
        }
        
        public List<AreaModel> GetAll()
        {
            List<AreaModel> list = new List<AreaModel>();
            try
            {
                string sqlString = "Select * from Area";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var areaModel = new AreaModel();
                    areaModel.Id = (int)reader["Id"];
                    areaModel.Descripcion =(string) reader["Id"];
                    areaModel.ProgramarTurnos = (bool)reader["ProgramarTurnos"];
                    areaModel.CambiosEnPeriodo = (bool)reader["CambiosEnPeriodo"];
                    areaModel.Email = (string)reader["Email"];
                    list.Add(areaModel);
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