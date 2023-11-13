using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using CapaNegocio;

namespace Proyecto
{
    public partial class MainMenu : Form
    {
        private E_Usuarios _usuario;
        private E_Logs Logeo = new E_Logs();
        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void timer1_Tick(object sender, EventArgs e)
        {
            TiempoFechaLb.Text = DateTime.Now.ToString();
        }
        public MainMenu(E_Usuarios usuario)
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

            Temporizador.Start();
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
            NombreLB.Text = _usuario.Username;
            EmailLb.Text = _usuario.Email;

            ReportesBT.FlatAppearance.BorderSize = 0;
            TablasBT.FlatAppearance.BorderSize = 0;
            PerfilBT.FlatAppearance.BorderSize = 0;
            ContactarnosBT.FlatAppearance.BorderSize = 0;
            CerrarSesionBT.FlatAppearance.BorderSize = 0;
            Logeo.IdUsuario = _usuario.IdUsuario;
            Logeo.LoginTime = DateTime.Now;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                connection.Open();

                string query = "Update Usuario set Activo = 0 where Username = @username and Passwrd = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", _usuario.Username);
                command.Parameters.AddWithValue("@password", _usuario.Passwrd);
                command.ExecuteNonQuery();

                connection.Close();
            }
            Application.Exit();
        }
        
        private void menu(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            switch (btn.Tag)
            {
                case "Perfil":
                    AbrirFormulariosEnWrapper(new PerfilFrm(_usuario));
                    break;
                
                case "Tablas":
                    AbrirFormulariosEnWrapper(new MenuCRUDs(_usuario));
                    break;
                case "Reportes":
                    AbrirFormulariosEnWrapper(new MenuReportes(_usuario));
                    break;
                    /*case "Multiplicacion":
                        AbrirFormulariosEnWrapper(new Multiplicacion());
                        break;
                    case "Area Cuadrado":
                        AbrirFormulariosEnWrapper(new AreaCuadrado());
                        break;
                    case "Area Rectangulo":
                        AbrirFormulariosEnWrapper(new AreaRectangulo());
                        break;
                   */

            };
        }

        private Form formActivado = null;
        private void AbrirFormulariosEnWrapper(Form FormHijo)
        {
            if (formActivado != null)
            {
                formActivado.Close();
            }
            formActivado = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;
            Wrapper.Controls.Add(FormHijo);
            Wrapper.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }

        private void CerrarSesionBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                connection.Open();

                string query = "Update Usuario set Activo = 0 where Username = @username and Passwrd = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", _usuario.Username);
                command.Parameters.AddWithValue("@password", _usuario.Passwrd);
                command.ExecuteNonQuery();

            }
            Application.Restart();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                connection.Open();

                string query = "Update Usuario set Activo = 0 where Username = @username and Passwrd = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", _usuario.Username);
                command.Parameters.AddWithValue("@password", _usuario.Passwrd);
                command.ExecuteNonQuery();

                string query2 = "Insert into Logs values(@IdUsuario, @LoginTime, @LogoutTime)";
                command = new SqlCommand(query2, connection);
                command.Parameters.AddWithValue("@IdUsuario", Logeo.IdUsuario);
                command.Parameters.AddWithValue("@LoginTime", Logeo.LoginTime);
                command.Parameters.AddWithValue("@LogoutTime", DateTime.Now);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void ContactarnosBT_Click(object sender, EventArgs e)
        {
            string recipient = "denzelrodri@gmail.com";
            string subject = "Contactando sobre el programa";
            string body = "Quiero hablarle de algo de su sistema!";

            string uri = string.Format("mailto:{0}?subject={1}&body={2}", recipient, subject, body);

            Process.Start(uri);
        }
    }
}
