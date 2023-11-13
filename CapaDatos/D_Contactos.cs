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
using System.Diagnostics.Contracts;

namespace CapaDatos
{
    public class D_Contactos
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Contactos> ListarContactos(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAContactos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Descripcion", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Contactos> Listar = new List<E_Contactos>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Contactos
                {
                    IdContacto = LeerFilas.GetInt32(0),
                    Descripcion = LeerFilas.GetString(1),
                    Telefono = LeerFilas.GetString(2),
                    Creado_por = LeerFilas.GetInt32(3)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarContactos(E_Contactos Contactos)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAContactos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Descripcion", Contactos.Descripcion);
            cmd.Parameters.AddWithValue("@Telefono", Contactos.Telefono);
            cmd.Parameters.AddWithValue("@Creado_por", Contactos.Creado_por);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarContactos(E_Contactos Contactos)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAContactos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdContacto", Contactos.IdContacto);
            cmd.Parameters.AddWithValue("@Descripcion", Contactos.Descripcion);
            cmd.Parameters.AddWithValue("@Telefono", Contactos.Telefono);
            cmd.Parameters.AddWithValue("@Creado_por", Contactos.Creado_por);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarContactos(E_Contactos Contactos)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAContactos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdContacto", Contactos.IdContacto);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
