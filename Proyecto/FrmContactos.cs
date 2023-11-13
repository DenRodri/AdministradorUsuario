using CapaEntidades;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Proyecto
{
    public partial class FrmContactos : Form
    {
        E_Usuarios _usuario = new E_Usuarios();
        public FrmContactos(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.tablaContactos.DefaultCellStyle.ForeColor = Color.Black;


        }
        private bool Editarse = false;
   

        E_Contactos objEntidad = new E_Contactos();
        N_Contactos objNegocio = new N_Contactos();




        private void FrmContactos_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();


        }
        public void accionesTabla()
        {

            tablaContactos.Columns[0].Visible = false;
            tablaContactos.Columns[1].HeaderText = "Descripcion";
            tablaContactos.Columns[2].HeaderText = "Telefono";
            tablaContactos.Columns[3].HeaderText = "Creador";


            tablaContactos.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Contactos objNegocio = new N_Contactos();
            tablaContactos.DataSource = objNegocio.ListandoContactos(buscar);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string formattedPhone = FormatPhoneNumber(txtTelefono.Text);
            txtTelefono.Text = formattedPhone;
            txtTelefono.SelectionStart = formattedPhone.Length;
        }

        private string FormatPhoneNumber(string input)
        {
            string digitsOnly = Regex.Replace(input, @"[^\d]", "");

            if (digitsOnly.Length > 0)
            {
                digitsOnly = digitsOnly.Substring(0, Math.Min(10, digitsOnly.Length));
                digitsOnly = Regex.Replace(digitsOnly, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            }

            return digitsOnly;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }
        private void limpiarCajas()
        {
            txtDescripcion.Text = "";
            txtTelefono.Text = "";
            tablaContactos.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            limpiarCajas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaContactos.SelectedRows.Count > 0)
            {
                Editarse = true;
                txtDescripcion.Text = tablaContactos.CurrentRow.Cells[1].Value.ToString();
                txtTelefono.Text = tablaContactos.CurrentRow.Cells[2].Value.ToString();



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
                    objEntidad.Descripcion = txtDescripcion.Text;
                    objEntidad.Telefono = txtTelefono.Text;
                    objEntidad.Creado_por = _usuario.IdUsuario;

                    objNegocio.InsertandoContactos(objEntidad);

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
                    objEntidad.IdContacto = Convert.ToInt32(tablaContactos.CurrentRow.Cells[0].Value);
                    objEntidad.Descripcion = txtDescripcion.Text;
                    objEntidad.Telefono = txtTelefono.Text;
                    objEntidad.Creado_por = _usuario.IdUsuario;

                    objNegocio.EditandoContactos(objEntidad);

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
            if (tablaContactos.SelectedRows.Count > 0)
            {
                objEntidad.IdContacto = Convert.ToInt32(tablaContactos.CurrentRow.Cells[0].Value);
                objNegocio.EliminandoContactos(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que deseas eliminar");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tablaContactos.Rows.Count > 0)

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

                            PdfPTable pTable = new PdfPTable(tablaContactos.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in tablaContactos.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in tablaContactos.Rows)

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
                    DataTable dt = Excel.DataGridView_To_Datatable(tablaContactos);
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
