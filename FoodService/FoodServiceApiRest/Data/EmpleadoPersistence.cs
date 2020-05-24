using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Data
{
    public class EmpleadoPersistence
    {
        private SqlConnection conn = new SqlConnection();

        public EmpleadoPersistence()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConexionGenius"].ConnectionString;
            conn.ConnectionString = strConnString;
            conn.Open();
        }

        public List<EmpleadoModel> GetAll()
        {
            List<EmpleadoModel> list = new List<EmpleadoModel>();
            try
            {
                string sqlString = "Select * from Empleado";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new EmpleadoModel();
                    obj.Id = (int)reader["IdEmpleado"];
                    obj.IdArea = (int)reader["IdArea"];
                    obj.Cedula = (string)reader["Cedula"];
                    obj.Nombre = (string)reader["Nombre"];
                    obj.EsAdministrador = (bool)reader["EsAdministrador"];
                    obj.EsSuperUsuario = (bool)reader["EsSuperUsuario"];
                    obj.Activo = (bool)reader["Activo"];
                    obj.EsAdministrativo = (bool)reader["EsAdministrativo"];
                    obj.UserName = (string)reader["UserName"];
                    obj.TipoContrato = (string)reader["TipoContrato"];
                    obj.AutoProgramar = (bool)reader["AutoProgramar"];
                    obj.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    obj.EsBodegaExterna = (bool)reader["EsBodegaExterna"];
                    obj.IdBodegaExterna = (int)reader["IdBodegaExterna"];
                    obj.Telefono = (string)reader["Telefono"];
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

        public List<EmpleadoModel> GetByArea(long idArea)
        {
            List<EmpleadoModel> list = new List<EmpleadoModel>();
            try
            {
                string sqlString = "Select * from Empleado where idArea = " + idArea;
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new EmpleadoModel();
                    obj.Id = (int)reader["IdEmpleado"];
                    obj.IdArea = (int)reader["IdArea"];
                    obj.Cedula = (string)reader["Cedula"];
                    obj.Nombre = (string)reader["Nombre"];
                    obj.EsAdministrador = (bool)reader["EsAdministrador"];
                    obj.EsSuperUsuario = (bool)reader["EsSuperUsuario"];
                    obj.Activo = (bool)reader["Activo"];
                    obj.EsAdministrativo = (bool)reader["EsAdministrativo"];
                    obj.UserName = (string)reader["UserName"];
                    obj.TipoContrato = (string)reader["TipoContrato"];
                    obj.AutoProgramar = (bool)reader["AutoProgramar"];
                    obj.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    obj.EsBodegaExterna = (bool)reader["EsBodegaExterna"];
                    obj.IdBodegaExterna = (int)reader["IdBodegaExterna"];
                    obj.Telefono = (string)reader["Telefono"];
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


        public EmpleadoModel Get(long id)
        {
            try
            {
                var obj = new EmpleadoModel();
                string sqlString = "Select * from Empleado where idEmpleado = " + id;
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.Id = (int)reader["IdEmpleado"];
                    obj.IdArea = (int)reader["IdArea"];
                    obj.Cedula = (string)reader["Cedula"];
                    obj.Nombre = (string)reader["Nombre"];
                    obj.EsAdministrador = (bool)reader["EsAdministrador"];
                    obj.EsSuperUsuario = (bool)reader["EsSuperUsuario"];
                    obj.Activo = (bool)reader["Activo"];
                    obj.EsAdministrativo = (bool)reader["EsAdministrativo"];
                    obj.UserName = (string)reader["UserName"];
                    obj.TipoContrato = (string)reader["TipoContrato"];
                    obj.AutoProgramar = (bool)reader["AutoProgramar"];
                    obj.FechaIngreso = (DateTime)reader["FechaIngreso"];
                    obj.EsBodegaExterna = (bool)reader["EsBodegaExterna"];
                    obj.IdBodegaExterna = (int)reader["IdBodegaExterna"];
                    obj.Telefono = (string)reader["Telefono"];
                }
                ProgramacionPersistence pp = new ProgramacionPersistence();
                obj.Programacion = pp.GetByEmpleado(obj.Id);
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