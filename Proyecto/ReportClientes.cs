using Microsoft.Reporting.WinForms;
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
    public partial class ReportClientes : Form
    {
        string _Date1, _Date2;
        public ReportClientes(DateTime date1, DateTime date2)
        {
            InitializeComponent();
            _Date1 = date1.ToString();
            _Date2 = date2.ToString();
        }

        private void ReportClientes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Clientes' table. You can move, or remove it, as needed.
            this.clientesTableAdapter.Fill(this.dataSet.Clientes, "2022-1-3", "2023-5-3");
            // TODO: This line of code loads data into the 'dataSet.Empresa' table. You can move, or remove it, as needed.
            this.empresaTableAdapter.Fill(this.dataSet.Empresa);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            this.reportViewer1.ZoomMode = ZoomMode.Percent;

            this.reportViewer1.ZoomPercent = 100;


            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
