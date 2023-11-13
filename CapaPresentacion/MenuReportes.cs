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

namespace Proyecto
{
    public partial class MenuReportes : Form
    {
        E_Usuarios _usuario = new E_Usuarios();

        public MenuReportes(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }
        private void menu(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            switch (btn.Tag)
            {
                case "Clientes":
                    AbrirFormulariosEnWrapper(new ListReportClientes());
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
