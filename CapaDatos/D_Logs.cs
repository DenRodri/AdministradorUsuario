using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace CapaDatos
{
    public class D_Logs
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Logs> ListarLogs(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRALogs", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "IdUsuario" || buscar == "")
            {
                cmd.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@IdUsuario", buscar);
            }
            LeerFilas = cmd.ExecuteReader();

            List<E_Logs> Listar = new List<E_Logs>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Logs
                {
                    IdUsuario = LeerFilas.GetInt32(0),
                    LoginTime = LeerFilas.GetDateTime(1),
                    LogoutTime = LeerFilas.GetDateTime(2)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarLogs(E_Logs Logs)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTALogs", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdUsuario", Logs.IdUsuario);
            cmd.Parameters.AddWithValue("@LoginTime", Logs.LoginTime);
            cmd.Parameters.AddWithValue("@LogoutTime", Logs.LogoutTime);




            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarLogs(E_Logs Logs)
        {
            SqlCommand cmd = new SqlCommand("SPEDITALogs", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdUsuario", Logs.IdUsuario);
            cmd.Parameters.AddWithValue("@LoginTime", Logs.LoginTime);
            cmd.Parameters.AddWithValue("@LogoutTime", Logs.LogoutTime);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarLogs(E_Logs Logs)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINALogs", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdUsuario", Logs.IdUsuario);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
