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
                    var obj = new AreaModel();
                    obj.Id = (int)reader["IdArea"];
                    obj.Descripcion =(string) reader["Descripcion"];
                    obj.ProgramarTurnos = (bool)reader["ProgramarTurnos"];
                    obj.CambiosEnPeriodo = (bool)reader["CambiosEnPeriodo"];
                    obj.Email = (string)reader["Email"];
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

        public AreaModel GetArea(int id)
        {
            try
            {
                var obj = new AreaModel();
                string sqlString = "Select * from Area where idArea = " + id;
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.Id = (int)reader["IdArea"];
                    obj.Descripcion = (string)reader["Descripcion"];
                    obj.ProgramarTurnos = (bool)reader["ProgramarTurnos"];
                    obj.CambiosEnPeriodo = (bool)reader["CambiosEnPeriodo"];
                    obj.Email = (string)reader["Email"];
                }
                EmpleadoPersistence ep = new EmpleadoPersistence();
                obj.Empleados = ep.GetByArea(obj.Id);
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null; // return the list
        }

        public bool AddArea(AreaModel obj)
        {
            try
            {
                string sqlString = "insert into Area(Descripcion,ProgramarTurnos,CambiosEnPeriodo,Email)" +
                                    "Values('" + obj.Descripcion + "'" +
                                    "," + Convert.ToInt32(obj.ProgramarTurnos).ToString() + 
                                    "," + Convert.ToInt32(obj.CambiosEnPeriodo).ToString() +
                                    ",'" + obj.Email + "')";

                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateArea(AreaModel obj)
        {
            try
            {
                string sqlString = "Update Area set Descripcion = '" + obj.Descripcion + "'" +
                                    ",ProgramarTurnos = " + Convert.ToInt32(obj.ProgramarTurnos).ToString() +
                                    ",CambiosEnPeriodo = " + Convert.ToInt32(obj.CambiosEnPeriodo).ToString() +
                                    ",Email = '" + obj.Email + "'" +
                                    " Where idArea = " + obj.Id;

                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string sqlString = "Delete from Area Where idArea = " + id;

                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}