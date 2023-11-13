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
    public class D_Propiedades
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Propiedades> ListarPropiedades(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAPROPIEDADES", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            if (buscar == "ID" || buscar == "")
            {
                cmd.Parameters.AddWithValue("@idPropiedad", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@idPropiedad", buscar);
            }
            LeerFilas = cmd.ExecuteReader();

            List<E_Propiedades> Listar = new List<E_Propiedades>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Propiedades
                {
                    IdPropiedad = LeerFilas.GetInt32(0),
                    Calle = LeerFilas.GetString(1),
                    Sector = LeerFilas.GetString(2),
                    Municipio = LeerFilas.GetString(3),
                    Provincia = LeerFilas.GetString(4),
                    Creado_por = LeerFilas.GetInt32(5),
                    CantBathroom = LeerFilas.GetInt32(6),
                    CantRooms = LeerFilas.GetInt32(7),
                    NumeroParqueo = LeerFilas.GetInt32(8),
                    Costo_Noche = LeerFilas.GetDecimal(9),
                    Oferta = LeerFilas.GetInt32(10),
                    Fecha_Compra = LeerFilas.GetDateTime(11),
                    Compro_Costo = LeerFilas.GetDecimal(12),
                    TipoCasa = LeerFilas.GetString(13),
                    Disponible = LeerFilas.GetBoolean(14)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarPropiedades(E_Propiedades Propiedades)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAPROPIEDADES", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Calle", Propiedades.Calle);
            cmd.Parameters.AddWithValue("@Sector", Propiedades.Sector);
            cmd.Parameters.AddWithValue("@Municipio", Propiedades.Municipio);
            cmd.Parameters.AddWithValue("@Provincia", Propiedades.Provincia);
            cmd.Parameters.AddWithValue("@Creado_Por", Propiedades.Creado_por);
            cmd.Parameters.AddWithValue("@CantBathroom", Propiedades.CantBathroom);
            cmd.Parameters.AddWithValue("@CantRooms", Propiedades.CantRooms);
            cmd.Parameters.AddWithValue("@NumeroParqueo", Propiedades.NumeroParqueo);
            cmd.Parameters.AddWithValue("@Costo_Noche", Propiedades.Costo_Noche);
            cmd.Parameters.AddWithValue("@Oferta", Propiedades.Oferta);
            cmd.Parameters.AddWithValue("@Fecha_Compra", Propiedades.Fecha_Compra);
            cmd.Parameters.AddWithValue("@Compro_Costo", Propiedades.Compro_Costo);
            cmd.Parameters.AddWithValue("@TipoCasa", Propiedades.TipoCasa);
            cmd.Parameters.AddWithValue("@Disponible", Propiedades.Disponible);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarPropiedades(E_Propiedades Propiedades)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAPROPIEDADES", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idPropiedad", Propiedades.IdPropiedad); 
            cmd.Parameters.AddWithValue("@Calle", Propiedades.Calle);
            cmd.Parameters.AddWithValue("@Sector", Propiedades.Sector);
            cmd.Parameters.AddWithValue("@Municipio", Propiedades.Municipio);
            cmd.Parameters.AddWithValue("@Provincia", Propiedades.Provincia);
            cmd.Parameters.AddWithValue("@Creado_Por", Propiedades.Creado_por);
            cmd.Parameters.AddWithValue("@CantBathroom", Propiedades.CantBathroom);
            cmd.Parameters.AddWithValue("@CantRooms", Propiedades.CantRooms);
            cmd.Parameters.AddWithValue("@NumeroParqueo", Propiedades.NumeroParqueo);
            cmd.Parameters.AddWithValue("@Costo_Noche", Propiedades.Costo_Noche);
            cmd.Parameters.AddWithValue("@Oferta", Propiedades.Oferta);
            cmd.Parameters.AddWithValue("@Fecha_Compra", Propiedades.Fecha_Compra);
            cmd.Parameters.AddWithValue("@Compro_Costo", Propiedades.Compro_Costo);
            cmd.Parameters.AddWithValue("@TipoCasa", Propiedades.TipoCasa);
            cmd.Parameters.AddWithValue("@Disponible", Propiedades.Disponible);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarPropiedades(E_Propiedades Propiedades)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAPROPIEDAD", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idPropiedad", Propiedades.IdPropiedad);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
