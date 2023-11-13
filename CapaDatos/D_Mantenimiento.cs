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
    public class D_Mantenimiento
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Mantenimiento> ListarMantenimiento1(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAMantenimiento", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdPropiedad", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Mantenimiento> Listar = new List<E_Mantenimiento>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Mantenimiento
                {
                    IdMantenimiento = LeerFilas.GetInt32(0),
                    IdPropiedad = LeerFilas.GetInt32(1),
                    Descripcion = LeerFilas.GetString(2),
                    Costo = LeerFilas.GetDecimal(3),
                    Creado_por = LeerFilas.GetInt32(4)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public List<E_Mantenimiento> ListarMantenimiento2(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAMantenimiento2", conexion);
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

            List<E_Mantenimiento> Listar = new List<E_Mantenimiento>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Mantenimiento
                {
                    IdMantenimiento = LeerFilas.GetInt32(0),
                    IdPropiedad = LeerFilas.GetInt32(1),
                    Descripcion = LeerFilas.GetString(2),
                    Costo = LeerFilas.GetDecimal(3),
                    Creado_por = LeerFilas.GetInt32(4)

                });

            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarMantenimiento(E_Mantenimiento Mantenimiento)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAMantenimiento", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdPropiedad", Mantenimiento.IdPropiedad);
            cmd.Parameters.AddWithValue("@Descripcion", Mantenimiento.Descripcion);
            cmd.Parameters.AddWithValue("@Costo", Mantenimiento.Costo);
            cmd.Parameters.AddWithValue("@Creado_por", Mantenimiento.Creado_por);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarMantenimiento(E_Mantenimiento Mantenimiento)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAMantenimiento", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdMantenimiento", Mantenimiento.IdMantenimiento);
            cmd.Parameters.AddWithValue("@IdPropiedad", Mantenimiento.IdPropiedad);
            cmd.Parameters.AddWithValue("@Descripcion", Mantenimiento.Descripcion);
            cmd.Parameters.AddWithValue("@Costo", Mantenimiento.Costo);
            cmd.Parameters.AddWithValue("@Creado_por", Mantenimiento.Creado_por);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarMantenimiento(E_Mantenimiento Mantenimiento)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAMantenimiento", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdMantenimiento", Mantenimiento.IdMantenimiento);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
