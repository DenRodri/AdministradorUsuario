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
    public class D_PropiedadResidenciales
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_PropiedadResidenciales> ListarPropiedadResidenciales(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAPropResi", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "IdResidencial" || buscar == "")
            {
                cmd.Parameters.AddWithValue("@IdResidencial", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@IdResidencial", buscar);
            }

            LeerFilas = cmd.ExecuteReader();

            List<E_PropiedadResidenciales> Listar = new List<E_PropiedadResidenciales>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_PropiedadResidenciales
                {
                    IdPropiedad = LeerFilas.GetInt32(0),
                    IdResidencial = LeerFilas.GetInt32(1)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarPropiedadResidenciales(E_PropiedadResidenciales PropiedadResidenciales)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAPropResi", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdPropiedad", PropiedadResidenciales.IdPropiedad);
            cmd.Parameters.AddWithValue("@IdResidencial", PropiedadResidenciales.IdResidencial);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarPropiedadResidenciales(E_PropiedadResidenciales PropiedadResidenciales)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAPropResi", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdPropiedad", PropiedadResidenciales.IdPropiedad);
            cmd.Parameters.AddWithValue("@IdResidencial", PropiedadResidenciales.IdResidencial);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarPropiedadResidenciales(E_PropiedadResidenciales PropiedadResidenciales)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAPropResi", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdPropiedad", PropiedadResidenciales.IdPropiedad);
            cmd.Parameters.AddWithValue("@IdResidencial", PropiedadResidenciales.IdResidencial);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
