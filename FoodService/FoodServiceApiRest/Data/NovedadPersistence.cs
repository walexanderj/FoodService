using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Data
{
    public class NovedadPersistence
    {
        private SqlConnection conn = new SqlConnection();

        public NovedadPersistence()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConexionGenius"].ConnectionString;
            conn.ConnectionString = strConnString;
            conn.Open();
        }

        public List<NovedadModel> GetByEmpleado(long idEmpleado)
        {
            List<NovedadModel> list = new List<NovedadModel>();
            try
            {
                string sqlString = "Select top 20 * from Novedad where idEmpleado = " + idEmpleado + " and isnull(anulado,0) = 0 Order by fecha desc";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new NovedadModel();
                    obj.Id = (int)reader["IdNovedad"];
                    obj.IdEmpleado = (int)reader["IdEmpleado"];
                    obj.Fecha = (DateTime)reader["Fecha"];
                    obj.Detalle = (string)reader["Detalle"].ToString();
                    obj.NoAlimentacion = (bool)reader["NoAlimentacion"];
                    obj.Notas = (string)reader["Notas"].ToString();
                    obj.FechaIng = (DateTime)reader["FechaIng"];
                    obj.UsuarioIng = (string)reader["UsuarioIng"].ToString();
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

        public bool AddNovedad(NovedadModel obj)
        {
            try
            {
                string sqlString = "insert into Novedad(IdEmpleado,Fecha,Detalle,NoAlimentacion,Notas,FechaIng,UsuarioIng,Anulado,GeneraNC) " +
                                    "Values(" + obj.IdEmpleado + 
                                    ",'" + obj.Fecha.ToString("yyyyMMdd") + "'" +
                                    ",'" + obj.Detalle + "'" +
                                    "," + Convert.ToInt16(obj.NoAlimentacion) +
                                    ",'" + obj.Notas + "'" +
                                    ",GetDate()" + 
                                    ",'" + obj.UsuarioIng + "'" +
                                    ",0" + 
                                    ",0)";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                ProgramacionPersistence pp = new ProgramacionPersistence();


                if (obj.idTurnoDetalle == 0)
                {
                    if (obj.NoAlimentacion == true)
                    {
                        pp.CancelarProgramacion(obj.IdEmpleado, obj.Fecha);
                    }
                    else
                    {
                        pp.Programar(obj.IdEmpleado, obj.Fecha);
                    }
                }
                else
                {
                    pp.CambiarTurno(obj.IdEmpleado, obj.Fecha, obj.idTurnoDetalle,obj.idPlato);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}