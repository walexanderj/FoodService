using FoodServiceApiRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServiceApiRest.Data
{
    public class ProgramacionPersistence
    {
        private SqlConnection conn = new SqlConnection();
        public ProgramacionPersistence()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConexionGenius"].ConnectionString;
            conn.ConnectionString = strConnString;
            conn.Open();
        }
        public List<ProgramacionModel> GetByEmpleado(long idEmpleado)
        {
            List<ProgramacionModel> list = new List<ProgramacionModel>();
            try
            {
                string sqlString = "select consec, fecha, idEmpleado,Programacion.idPlato,plato.Descripcion Plato,cantidad,Programacion.idTurno,Turno.Descripcion Turno,idPeriodo " +
                                    "from programacion inner join plato on plato.idPlato = programacion.IdPlato " +
                                    "inner join TurnoDetalle on TurnoDetalle.IdTurnoDetalle = Programacion.IdTurno " +
                                    "inner join Turno on Turno.IdTurno = TurnoDetalle.IdTurno " +
                                    "where idEmpleado = " + idEmpleado + " and Fecha >= convert(date,getdate())";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new ProgramacionModel();
                    obj.Id = (int)reader["consec"];
                    obj.Fecha = (DateTime)reader["fecha"];
                    obj.IdEmpleado = (int)reader["idEmpleado"];
                    obj.IdPlato = (int)reader["idPlato"];
                    obj.Plato = (string)reader["Plato"];
                    obj.Cantidad = (int)reader["cantidad"];
                    obj.IdTurno = (int)reader["idTurno"];
                    obj.Turno = (string)reader["Turno"];
                    obj.IdPeriodo = (int)reader["idPeriodo"];
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

        internal void CancelarProgramacion(long idEmpleado, DateTime fecha)
        {
            try
            {
                string sqlString = "Update Programacion set cantidad = 0 "  +
                                   "Where IdEmpleado = " + idEmpleado +
                                   "and fecha = '" + fecha.ToString("yyyyMMdd") + "'";

                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }

        }

        internal void Programar(long idEmpleado, DateTime fecha)
        {
            try
            {
                string sqlString = "Update Programacion set cantidad = 1 " +
                                   "Where IdEmpleado = " + idEmpleado +
                                   "and fecha = '" + fecha.ToString("yyyyMMdd") + "'";

                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }

        internal void CambiarTurno(long idEmpleado, DateTime fecha, long idTurnoDetalle, long idPlato)
        {
            try
            {
                string sqlString = "Insert into CambioTurnos(Fecha, IdEmpleado, IdTurno, IdPlato) " +
                                   "select '" + fecha.ToString("yyyyMMdd") + "'" +
                                   "," + idEmpleado + 
                                   "," + idTurnoDetalle +
                                   "," + idPlato +
                                   "Update Programacion set cantidad = 1 " +
                                   "idTurno = " + idTurnoDetalle +
                                   "idPlato = " + idPlato +
                                   "Where IdEmpleado = " + idEmpleado +
                                   "and fecha = '" + fecha.ToString("yyyyMMdd") + "'";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }

        public List<ProgramaDiaModel> ProgramaDia(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<ProgramaDiaModel> list = new List<ProgramaDiaModel>();
            try
            {
                string sqlString = "Execute SP_ImprimeProgramacionXPlato '" + fechaInicio.ToString("yyyyMMdd") + "'"  + ",'" + fechaFinal.ToString("yyyyMMdd") + "'";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    var obj = new ProgramaDiaModel();
                    obj.Id = i;
                    obj.Fecha = (DateTime)reader["fecha"];
                    obj.Dia = (string)reader["Dia"];
                    obj.Plato = (string)reader["Plato"];
                    obj.Cantidad = (int)reader["cantidad"];
                    obj.HoraPrograma = (string)reader["HoraPrograma"];
                    list.Add(obj);
                    i += 1;
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