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
    public class D_Transferencia
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Transferencia> ListarTransferencia1(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRATransferencia1", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "IdPropiedad" || buscar == "")
            {
                cmd.Parameters.AddWithValue("@idPropiedad", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@idPropiedad", buscar);
            }

            LeerFilas = cmd.ExecuteReader();

            List<E_Transferencia> Listar = new List<E_Transferencia>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Transferencia
                {
                    IdTransferencia = LeerFilas.GetInt32(0),
                    IdProducto = LeerFilas.GetInt32(1),
                    IdPropiedad = LeerFilas.GetInt32(2),
                    Cantidad = LeerFilas.GetInt32(3),
                    Fecha = LeerFilas.GetDateTime(4),
                    Movido_Por = LeerFilas.GetInt32(5)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }
        public List<E_Transferencia> ListarTransferencia2(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRATransferencia2", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdProducto", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Transferencia> Listar = new List<E_Transferencia>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Transferencia
                {
                    IdTransferencia = LeerFilas.GetInt32(0),
                    IdProducto = LeerFilas.GetInt32(1),
                    IdPropiedad = LeerFilas.GetInt32(2),
                    Cantidad = LeerFilas.GetInt32(3),
                    Fecha = LeerFilas.GetDateTime(4),
                    Movido_Por = LeerFilas.GetInt32(5)

                });

            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }
        public List<E_Transferencia> ListarTransferencia3(string buscar1, string buscar2)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRATransferencia3", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdProducto", buscar1);
            cmd.Parameters.AddWithValue("@IdPropiedad", buscar2);

            LeerFilas = cmd.ExecuteReader();

            List<E_Transferencia> Listar = new List<E_Transferencia>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Transferencia
                {
                    IdTransferencia = LeerFilas.GetInt32(0),
                    IdProducto = LeerFilas.GetInt32(1),
                    IdPropiedad = LeerFilas.GetInt32(2),
                    Cantidad = LeerFilas.GetInt32(3),
                    Fecha = LeerFilas.GetDateTime(4),
                    Movido_Por = LeerFilas.GetInt32(5)

                });

            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarTransferencia(E_Transferencia Transferencia)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTATransferencia", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdProducto", Transferencia.IdProducto);
            cmd.Parameters.AddWithValue("@IdPropiedad", Transferencia.IdPropiedad);
            cmd.Parameters.AddWithValue("@Cantidad", Transferencia.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha", Transferencia.Fecha);
            cmd.Parameters.AddWithValue("@Movido_por", Transferencia.Movido_Por);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarTransferencia(E_Transferencia Transferencia)
        {
            SqlCommand cmd = new SqlCommand("SPEDITATransferencia", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdTransferencia", Transferencia.IdTransferencia);
            cmd.Parameters.AddWithValue("@IdProducto", Transferencia.IdProducto);
            cmd.Parameters.AddWithValue("@IdPropiedad", Transferencia.IdPropiedad);
            cmd.Parameters.AddWithValue("@Cantidad", Transferencia.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha", Transferencia.Fecha);
            cmd.Parameters.AddWithValue("@Movido_por", Transferencia.Movido_Por);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarTransferencia(E_Transferencia Transferencia)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINATransferencia", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdTransferencia", Transferencia.IdTransferencia);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
