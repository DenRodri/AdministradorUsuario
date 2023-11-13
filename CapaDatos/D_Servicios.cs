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
    public class D_Servicios
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Servicios> ListarServicios(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAServicios", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "IdPropiedad" || buscar == "")
            {
                cmd.Parameters.AddWithValue("@IdPropiedad", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@IdPropiedad", buscar);
            }

            LeerFilas = cmd.ExecuteReader();

            List<E_Servicios> Listar = new List<E_Servicios>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Servicios
                {
                    IdServicio = LeerFilas.GetInt32(0),
                    IdPropiedad = LeerFilas.GetInt32(1),
                    Internet = LeerFilas.GetDecimal(2),
                    Luz = LeerFilas.GetDecimal(3)

            });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarServicios(E_Servicios Servicios)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAServicios", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdPropiedad", Servicios.IdPropiedad);
            cmd.Parameters.AddWithValue("@Internet", Servicios.Internet);
            cmd.Parameters.AddWithValue("@Luz", Servicios.Luz);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarServicios(E_Servicios Servicios)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAServicios", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdServicio", Servicios.IdServicio);
            cmd.Parameters.AddWithValue("@IdPropiedad", Servicios.IdPropiedad);
            cmd.Parameters.AddWithValue("@Internet", Servicios.Internet);
            cmd.Parameters.AddWithValue("@Luz", Servicios.Luz);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarServicios(E_Servicios Servicios)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAServicios", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdServicio", Servicios.IdPropiedad);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
