using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto
{
    public partial class MenuCRUDs : Form
    {
        E_Usuarios _usuario = new E_Usuarios();
        public MenuCRUDs(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            if(_usuario.Rol == 2)
            {
                MessageBox.Show("No tendra acceso a algunas de las tablas por ser empleado");
                button8.Enabled = false;
                button9.Enabled = false;
                button12.Enabled = false;
                button10.Enabled = false;
            }
        }
        private void menu(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            switch (btn.Tag)
            {
                case "Clientes":
                    AbrirFormulariosEnWrapper(new FrmClientes(_usuario));
                    break;
                case "Contactos":
                    AbrirFormulariosEnWrapper(new FrmContactos(_usuario));
                    break;
                case "Propiedades":
                    AbrirFormulariosEnWrapper(new FrmPropiedades(_usuario));
                    break;
                case "Residenciales":
                    AbrirFormulariosEnWrapper(new FrmResidenciales(_usuario));
                    break;
                case "Usuarios":
                    AbrirFormulariosEnWrapper(new FrmUsuarios(_usuario));
                    break;
                case "Servicios":
                    AbrirFormulariosEnWrapper(new FrmServicios(_usuario));
                    break;
                case "Productos":
                    AbrirFormulariosEnWrapper(new FrmProductos(_usuario));
                    break;
                case "Mantenimiento":
                    AbrirFormulariosEnWrapper(new FrmMantenimiento(_usuario));
                    break;
                case "Inventario":
                    AbrirFormulariosEnWrapper(new FrmInventario(_usuario));
                    break;
                case "Estadias":
                    AbrirFormulariosEnWrapper(new FrmEstadias(_usuario));
                    break;
                case "Logs":
                    AbrirFormulariosEnWrapper(new FrmLogs(_usuario));
                    break;
                case "PropiedadResidenciales":
                    AbrirFormulariosEnWrapper(new FrmPropiedadResidenciales(_usuario));
                    break;
                case "Transferencia":
                    AbrirFormulariosEnWrapper(new FrmTransferencia(_usuario));
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
        private void AbrirFormulariosEnWrapper(Form FormHijo)
        {
            FormHijo.BringToFront();
            FormHijo.Show();
        }
    }
}
