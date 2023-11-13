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
    public class D_Clientes
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Clientes> ListarClientes(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAClientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Clientes> Listar = new List<E_Clientes>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Clientes
                {
                    IdCliente = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Apellido = LeerFilas.GetString(2),
                    Nacionalidad = LeerFilas.GetString(3),
                    Sexo = LeerFilas.GetString(4),
                    Creado_Por = LeerFilas.GetInt32(5)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarClientes(E_Clientes Clientes)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAClientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", Clientes.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Clientes.Apellido);
            cmd.Parameters.AddWithValue("@Nacionalidad", Clientes.Nacionalidad);
            cmd.Parameters.AddWithValue("@Sexo", Clientes.Sexo);
            cmd.Parameters.AddWithValue("@Creado_Por", Clientes.Creado_Por);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarClientes(E_Clientes Clientes)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAClientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdCliente", Clientes.IdCliente);
            cmd.Parameters.AddWithValue("@Nombre", Clientes.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Clientes.Apellido);
            cmd.Parameters.AddWithValue("@Nacionalidad", Clientes.Nacionalidad);
            cmd.Parameters.AddWithValue("@Sexo", Clientes.Sexo);
            cmd.Parameters.AddWithValue("@Creado_Por", Clientes.Creado_Por);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarClientes(E_Clientes Clientes)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAClientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdCliente", Clientes.IdCliente);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
