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
    public class D_Usuarios
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Usuarios> ListarUsuarios(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SPMUESTRAUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            if (buscar == "Nombre")
            {
                cmd.Parameters.AddWithValue("@Nombre", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Nombre", buscar);
            }

            LeerFilas = cmd.ExecuteReader();

            List<E_Usuarios> Listar = new List<E_Usuarios>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Usuarios
                {
                    IdUsuario = LeerFilas.GetInt32(0),
                    Username = LeerFilas.GetString(1),
                    Passwrd = LeerFilas.GetString(2),
                    Nombre = LeerFilas.GetString(3),
                    Apellido = LeerFilas.GetString(4),
                    Email = LeerFilas.GetString(5),
                    Telefono = LeerFilas.GetString(6),
                    Sexo = LeerFilas.GetString(7),
                    Fecha_Nacimiento = LeerFilas.GetDateTime(8),
                    Fecha_Contrato = LeerFilas.GetDateTime(9),
                    Fecha_Creacion_Cuenta = LeerFilas.GetDateTime(10),
                    Activo = LeerFilas.GetBoolean(11),
                    Estado = LeerFilas.GetBoolean(12),
                    Rol = LeerFilas.GetInt32(13),
                    Creado_Por = LeerFilas.GetInt32(14)

                });
                    
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarUsuarios(E_Usuarios Usuarios)
        {
            SqlCommand cmd = new SqlCommand("SPINSERTAUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Username", Usuarios.Username);
            cmd.Parameters.AddWithValue("@Passwrd", Usuarios.Passwrd);
            cmd.Parameters.AddWithValue("@Nombre", Usuarios.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Usuarios.Apellido);
            cmd.Parameters.AddWithValue("@Email", Usuarios.Email);
            cmd.Parameters.AddWithValue("@Telefono", Usuarios.Telefono);
            cmd.Parameters.AddWithValue("@Sexo", Usuarios.Sexo);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Usuarios.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("@Fecha_Contrato", Usuarios.Fecha_Contrato);
            cmd.Parameters.AddWithValue("@Fecha_Creacion_Cuenta", Usuarios.Fecha_Creacion_Cuenta);
            cmd.Parameters.AddWithValue("@Activo", Usuarios.Activo);
            cmd.Parameters.AddWithValue("@Estado", Usuarios.Estado);
            cmd.Parameters.AddWithValue("@Rol", Usuarios.Rol);
            cmd.Parameters.AddWithValue("@Creado_Por", Usuarios.Creado_Por);



            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarUsuarios(E_Usuarios Usuarios)
        {
            SqlCommand cmd = new SqlCommand("SPEDITAUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdUsuario", Usuarios.IdUsuario);
            cmd.Parameters.AddWithValue("@Username", Usuarios.Username);
            cmd.Parameters.AddWithValue("@Passwrd", Usuarios.Passwrd);
            cmd.Parameters.AddWithValue("@Nombre", Usuarios.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Usuarios.Apellido);
            cmd.Parameters.AddWithValue("@Email", Usuarios.Email);
            cmd.Parameters.AddWithValue("@Telefono", Usuarios.Telefono);
            cmd.Parameters.AddWithValue("@Sexo", Usuarios.Sexo);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Usuarios.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("@Fecha_Contrato", Usuarios.Fecha_Contrato);
            cmd.Parameters.AddWithValue("@Fecha_Creacion_Cuenta", Usuarios.Fecha_Creacion_Cuenta);
            cmd.Parameters.AddWithValue("@Activo", Usuarios.Activo);
            cmd.Parameters.AddWithValue("@Estado", Usuarios.Estado);
            cmd.Parameters.AddWithValue("@Rol", Usuarios.Rol);
            cmd.Parameters.AddWithValue("@Creado_Por", Usuarios.Creado_Por);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarUsuarios(E_Usuarios Usuarios)
        {
            SqlCommand cmd = new SqlCommand("SPELIMINAUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IdUsuario", Usuarios.IdUsuario);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public E_Usuarios GetUsuario(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Usuario WHERE Username = @username AND Passwrd = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        E_Usuarios usuario = new E_Usuarios();
                        usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        usuario.Username = Convert.ToString(reader["Username"]);
                        usuario.Passwrd = Convert.ToString(reader["Passwrd"]);
                        usuario.Nombre = Convert.ToString(reader["Nombre"]);
                        usuario.Apellido = Convert.ToString(reader["Apellido"]);
                        usuario.Email = Convert.ToString(reader["Email"]);
                        usuario.Telefono = Convert.ToString(reader["Telefono"]);
                        usuario.Sexo = Convert.ToString(reader["Sexo"]);
                        usuario.Fecha_Nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]);
                        usuario.Fecha_Contrato = Convert.ToDateTime(reader["Fecha_Contrato"]);
                        usuario.Fecha_Creacion_Cuenta = Convert.ToDateTime(reader["Fecha_Creacion_Cuenta"]);
                        usuario.Activo = Convert.ToBoolean(reader["Activo"]);
                        usuario.Estado = Convert.ToBoolean(reader["Estado"]);
                        usuario.Rol = Convert.ToInt32(reader["Rol"]);
                        usuario.Creado_Por = Convert.ToInt32(reader["Creado_Por"]);

                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
