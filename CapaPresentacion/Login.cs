using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;


namespace Proyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;

            N_Login loginLogic = new N_Login();
            E_Usuarios usuario = loginLogic.GetUsuario(username, password);

            if (usuario != null && usuario.Activo == false)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
                {
                    connection.Open();

                    string query = "Update Usuario set Activo = 1 where Username = @username and Passwrd = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                this.Hide();
                var form2 = new MainMenu(usuario);
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if (usuario == null)
            {
                MessageBox.Show("Nombre de usuario o contraseña invalidos");
            }
            else if (usuario.Estado == true)
            {
                MessageBox.Show("Esta cuenta esta cancelada");
            }
            else if (usuario.Activo == true)
            {
                MessageBox.Show("Esta cuenta esta activa en otro lugar");
            }
        }
    }
}
