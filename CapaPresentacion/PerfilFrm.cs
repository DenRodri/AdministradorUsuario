using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto
{
    public partial class PerfilFrm : Form
    {
        private E_Usuarios _usuario;
        public PerfilFrm(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            GraphicsPath path = new GraphicsPath();
            int radius = Math.Min(ImagenPerfilPB.Width, ImagenPerfilPB.Height) / 2;
            int x = ImagenPerfilPB.Width / 2 - radius;
            int y = ImagenPerfilPB.Height / 2 - radius;
            path.AddEllipse(x, y, radius * 2, radius * 2);

            ImagenPerfilPB.Region = new Region(path);


            Pen pen = new Pen(Color.Black, 1);

            pen.DashStyle = DashStyle.Solid;
            Graphics graphics = ImagenPerfilPB.CreateGraphics();
            graphics.DrawEllipse(pen, x, y, radius * 2, radius * 2);


            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string imagePath = Path.Combine(appPath, "Images\\Femenino.png");
            string imagePath2 = Path.Combine(appPath, "Images\\Masculino.png");
            if (_usuario.Sexo == "Masculino")
            {
                ImagenPerfilPB.Image = Image.FromFile(imagePath2);
            }
            else
            {
                ImagenPerfilPB.Image = Image.FromFile(imagePath);
            }
            label1.Text = _usuario.Nombre + " " + _usuario.Apellido;
            label4.Text = _usuario.Email;
            label5.Text = _usuario.Telefono;
            label6.Text = _usuario.Sexo;
            label8.Text = "Fecha de Contrato: " + String.Format("{0:M/d/yyyy}", _usuario.Fecha_Contrato);
            label9.Text = "Fecha de Creacion de Cuenta: " + String.Format("{0:M/d/yyyy}", _usuario.Fecha_Creacion_Cuenta);
            string rol;
            if (_usuario.Rol == 1)
            {
                rol = "Administrador";
            }
            else
            {
                rol = "Empleado";
            }
            label10.Text = "Rol: " + rol;
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Entre la nueva contraseña");
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
            try
            {
                // Open the connection to the database
                connection.Open();

                // Update the password in the database
                SqlCommand command = new SqlCommand("UPDATE usuario SET passwrd = @password WHERE username = @username", connection);
                command.Parameters.AddWithValue("@password", newPassword);
                command.Parameters.AddWithValue("@username", _usuario.Username);
                command.ExecuteNonQuery();

                MessageBox.Show("Se cambio la contraseña correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection to the database
                connection.Close();
            }
        }
    }
}
