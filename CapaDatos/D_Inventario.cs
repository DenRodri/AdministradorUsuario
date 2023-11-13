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
    public class D_Inventario
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Inventario> ListarInventario(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAInventario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "IdProducto" || buscar == "")
            {
                cmd.Parameters.AddWithValue("@IdProducto", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@IdProducto", buscar);
            }

            LeerFilas = cmd.ExecuteReader();

            List<E_Inventario> Listar = new List<E_Inventario>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Inventario
                {
                    IdInventario = LeerFilas.GetInt32(0),
                    IdProducto = LeerFilas.GetInt32(1),
                    Comprado_por = LeerFilas.GetInt32(2),
                    Cantidad = LeerFilas.GetInt32(3),
                    Fecha = LeerFilas.GetDateTime(4)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarInventario(E_Inventario Inventario)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAInventario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdProducto", Inventario.IdProducto);
            cmd.Parameters.AddWithValue("@Comprado_por", Inventario.Comprado_por);
            cmd.Parameters.AddWithValue("@Cantidad", Inventario.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha", Inventario.Fecha);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarInventario(E_Inventario Inventario)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAInventario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdInventario", Inventario.IdInventario);
            cmd.Parameters.AddWithValue("@IdProducto", Inventario.IdProducto);
            cmd.Parameters.AddWithValue("@Comprado_por", Inventario.Comprado_por);
            cmd.Parameters.AddWithValue("@Cantidad", Inventario.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha", Inventario.Fecha);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarInventario(E_Inventario Inventario)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAInventario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdInventario", Inventario.IdInventario);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
