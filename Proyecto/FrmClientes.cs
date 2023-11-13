using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Syncfusion.XlsIO;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

namespace Proyecto
{
    public partial class FrmClientes : Form
    {
        E_Usuarios _usuario = new E_Usuarios();
        public FrmClientes(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.tablaClientes.DefaultCellStyle.ForeColor = Color.Black;


        }
        private string idClientes;
        private bool Editarse = false;
        string sexo;

        E_Clientes objEntidad = new E_Clientes();
        N_Clientes objNegocio = new N_Clientes();

        
         List<string> cultureList = new List<string>();
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        RegionInfo region;

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();

            foreach (CultureInfo culture in cultures)
            {
                region = new RegionInfo(culture.LCID);
                if (!(cultureList.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName);
                    CountryCB.Items.Add(region.EnglishName + " (" + region.ISOCurrencySymbol+ ")");
                }
            }

        }
        public void accionesTabla()
        {

            tablaClientes.Columns[0].Visible = false;
            tablaClientes.Columns[1].HeaderText = "Nombre";
            tablaClientes.Columns[2].HeaderText = "Apellido";
            tablaClientes.Columns[3].HeaderText = "Nacionalidad";
            tablaClientes.Columns[4].HeaderText = "Sexo";
            tablaClientes.Columns[5].HeaderText = "Creador";


            tablaClientes.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Clientes objNegocio = new N_Clientes();
            tablaClientes.DataSource = objNegocio.ListandoClientes(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }
        private void limpiarCajas()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            tablaClientes.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            limpiarCajas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.SelectedRows.Count > 0)
            {
                Editarse = true;
                idClientes = tablaClientes.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = tablaClientes.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = tablaClientes.CurrentRow.Cells[2].Value.ToString();
                CountryCB.Text = tablaClientes.CurrentRow.Cells[3].Value.ToString();



            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txtNombre.Text;
                    objEntidad.Apellido = txtApellido.Text;
                    objEntidad.Nacionalidad = CountryCB.SelectedItem.ToString();
                    objEntidad.Sexo = sexo;
                    objEntidad.Creado_Por = _usuario.IdUsuario;

                    objNegocio.InsertandoClientes(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    mostrarBuscarTabla("");
                    Editarse = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
            if (Editarse == true)
            {
                try
                {
                    objEntidad.IdCliente = Convert.ToInt32(tablaClientes.CurrentRow.Cells[0].Value);
                    objEntidad.Nombre = txtNombre.Text;
                    objEntidad.Apellido = txtApellido.Text;
                    objEntidad.Nacionalidad = CountryCB.SelectedItem.ToString();
                    objEntidad.Sexo = sexo;
                    objEntidad.Creado_Por = _usuario.IdUsuario;

                    objNegocio.EditandoClientes(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    mostrarBuscarTabla("");
                    limpiarCajas();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.SelectedRows.Count > 0)
            {
                objEntidad.IdCliente  = Convert.ToInt32(tablaClientes.CurrentRow.Cells[0].Value);
                objNegocio.EliminandoClientes(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que deseas eliminar");
            }
        }

        private void MRB_CheckedChanged(object sender, EventArgs e)
        {
            if (MRB.Checked == true)
            {
                sexo = "Masculino";

            }
        }

        private void FRB_CheckedChanged(object sender, EventArgs e)
        {
            if (FRB.Checked == true)
            {
                sexo = "Femenino";

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tablaClientes.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Resultado.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(tablaClientes.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in tablaClientes.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in tablaClientes.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("Datos exportados exitosamente", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error mientras se exportaban los datos" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Records encontrados", "Info");

            }

        }



        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|Excel 2007 (*.xls)|*.xls";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = Excel.DataGridView_To_Datatable(tablaClientes);
                    dt.exportToExcel(openFileDialog.FileName);
                    MessageBox.Show("Data is exported!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

