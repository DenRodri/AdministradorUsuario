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
using System.Xml;

namespace CapaDatos
{
    public class D_Estadias
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Estadias> ListarEstadias(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAEstadias", conexion);
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

            List<E_Estadias> Listar = new List<E_Estadias>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Estadias
                {
                    IdCliente = LeerFilas.GetInt32(0),
                    IdPropiedad = LeerFilas.GetInt32(1),
                    IdEmpleado = LeerFilas.GetInt32(2),
                    CantNoches = LeerFilas.GetInt32(3),
                    Fecha = LeerFilas.GetDateTime(4),
                    Cancelacion = LeerFilas.GetBoolean(5),
                    Reembolso = LeerFilas.GetDecimal(6)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarEstadias(E_Estadias Estadias)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAEstadias", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdCliente", Estadias.IdCliente);
            cmd.Parameters.AddWithValue("@IdPropiedad", Estadias.IdPropiedad);
            cmd.Parameters.AddWithValue("@IdEmpleado", Estadias.IdEmpleado);
            cmd.Parameters.AddWithValue("@CantNoches", Estadias.CantNoches);
            cmd.Parameters.AddWithValue("@Fecha", Estadias.Fecha);
            cmd.Parameters.AddWithValue("@Cancelacion", Estadias.Cancelacion);
            cmd.Parameters.AddWithValue("@Reembolso", Estadias.Reembolso);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarEstadias(E_Estadias Estadias)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAEstadias", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdCliente", Estadias.IdCliente);
            cmd.Parameters.AddWithValue("@IdPropiedad", Estadias.IdPropiedad);
            cmd.Parameters.AddWithValue("@IdEmpleado", Estadias.IdEmpleado);
            cmd.Parameters.AddWithValue("@CantNoches", Estadias.CantNoches);
            cmd.Parameters.AddWithValue("@Fecha", Estadias.Fecha);
            cmd.Parameters.AddWithValue("@Cancelacion", Estadias.Cancelacion);
            cmd.Parameters.AddWithValue("@Reembolso", Estadias.Reembolso);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarEstadias(E_Estadias Estadias)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAEstadias", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdCliente", Estadias.IdCliente);
            cmd.Parameters.AddWithValue("@IdPropiedad", Estadias.IdPropiedad);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
