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
    public class D_Residenciales
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Residenciales> ListarResidenciales(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRARESIDENCIAL", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "Nombre de Residencial")
            {
                cmd.Parameters.AddWithValue("@Nombre", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Nombre", buscar);
            }

            LeerFilas = cmd.ExecuteReader();

            List<E_Residenciales> Listar = new List<E_Residenciales>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Residenciales
                {
                    IdResidencial = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Calle = LeerFilas.GetString(2),
                    Sector = LeerFilas.GetString(3),
                    Municipio = LeerFilas.GetString(4),
                    Provincia = LeerFilas.GetString(5),
                    Num_Contacto = LeerFilas.GetString(6),
                    Creado_Por = LeerFilas.GetInt32(7)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarResidenciales(E_Residenciales Residenciales)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTARESIDENCIAL", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", Residenciales.Nombre);
            cmd.Parameters.AddWithValue("@Calle", Residenciales.Calle);
            cmd.Parameters.AddWithValue("@Sector", Residenciales.Sector);
            cmd.Parameters.AddWithValue("@Municipio", Residenciales.Municipio);
            cmd.Parameters.AddWithValue("@Provincia", Residenciales.Provincia);
            cmd.Parameters.AddWithValue("@Num_Contacto", Residenciales.Num_Contacto);
            cmd.Parameters.AddWithValue("@Creado_Por", Residenciales.Creado_Por);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarResidenciales(E_Residenciales Residenciales)
        {
            SqlCommand cmd = new SqlCommand("SPEDITARESIDENCIAL", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdResidencial", Residenciales.IdResidencial);
            cmd.Parameters.AddWithValue("@Nombre", Residenciales.Nombre);
            cmd.Parameters.AddWithValue("@Calle", Residenciales.Calle);
            cmd.Parameters.AddWithValue("@Sector", Residenciales.Sector);
            cmd.Parameters.AddWithValue("@Municipio", Residenciales.Municipio);
            cmd.Parameters.AddWithValue("@Provincia", Residenciales.Provincia);
            cmd.Parameters.AddWithValue("@Num_Contacto", Residenciales.Num_Contacto);
            cmd.Parameters.AddWithValue("@Creado_Por", Residenciales.Creado_Por);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarResidenciales(E_Residenciales Residenciales)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAResidenciales", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idResidencial", Residenciales.IdResidencial);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
