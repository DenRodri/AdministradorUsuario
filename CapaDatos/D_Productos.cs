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
    public class D_Productos
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Productos> ListarProductos(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "Descripcion")
            {
                cmd.Parameters.AddWithValue("@Descripcion", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Descripcion", buscar);
            }

            LeerFilas = cmd.ExecuteReader();

            List<E_Productos> Listar = new List<E_Productos>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Productos
                {
                    IdProducto = LeerFilas.GetInt32(0),
                    Descripcion = LeerFilas.GetString(1),
                    Costo = LeerFilas.GetDecimal(2),
                    Cantidad = LeerFilas.GetInt32(3),
                    Fecha_Compra = LeerFilas.GetDateTime(4)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarProductos(E_Productos Productos)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Descripcion", Productos.Descripcion);
            cmd.Parameters.AddWithValue("@Costo", Productos.Costo);
            cmd.Parameters.AddWithValue("@Cantidad", Productos.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha_Compra", Productos.Fecha_Compra);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarProductos(E_Productos Productos)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdProducto", Productos.IdProducto);
            cmd.Parameters.AddWithValue("@Descripcion", Productos.Descripcion);
            cmd.Parameters.AddWithValue("@Costo", Productos.Costo);
            cmd.Parameters.AddWithValue("@Cantidad", Productos.Cantidad);
            cmd.Parameters.AddWithValue("@Fecha_Compra", Productos.Fecha_Compra);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarProductos(E_Productos Productos)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdProducto", Productos.IdProducto);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
