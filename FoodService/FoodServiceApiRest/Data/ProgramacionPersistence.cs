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
                string sqlString =  "select consec, fecha, idEmpleado,Programacion.idPlato,plato.Descripcion Plato,cantidad,Programacion.idTurno,Turno.Descripcion Turno,idPeriodo " +
                                    "from programacion inner join plato on plato.idPlato = programacion.IdPlato " +
                                    "inner join TurnoDetalle on TurnoDetalle.IdTurnoDetalle = Programacion.IdTurno " +
                                    "inner join Turno on Turno.IdTurno = TurnoDetalle.IdTurno " +
                                    "where idEmpleado = " + idEmpleado + " and Fecha >= convert(date,getdate())";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new ProgramacionModel();
                    obj.Id = (long)reader["consec"];
                    obj.Fecha = (DateTime)reader["fecha"];
                    obj.IdEmpleado = (long)reader["idEmpleado"];
                    obj.IdPlato = (int)reader["idPlato"];
                    obj.Plato = (string)reader["Plato"];
                    obj.Cantidad = (int)reader["cantidad"];
                    obj.IdTurno = (long)reader["idTurno"];
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
    }
}