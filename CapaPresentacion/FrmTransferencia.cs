using CapaEntidades;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class FrmTransferencia : Form
    {
        E_Usuarios _usuario = new E_Usuarios();
        public FrmTransferencia(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.tablaTransferencia.DefaultCellStyle.ForeColor = Color.Black;



        }
        private bool Editarse = false, disponible = true;

        E_Transferencia objEntidad = new E_Transferencia();
        N_Transferencia objNegocio = new N_Transferencia();


        private void TextBoxNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmTransferencia_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
            txtBuscar_LostFocus(this, e);

        }
        public void accionesTabla()
        {

            tablaTransferencia.Columns[0].Visible = false;
            tablaTransferencia.Columns[1].HeaderText = "Id de Producto";
            tablaTransferencia.Columns[2].HeaderText = "Id de Propiedad";
            tablaTransferencia.Columns[3].HeaderText = "Cantidad";
            tablaTransferencia.Columns[4].HeaderText = "Fecha";
            tablaTransferencia.Columns[5].HeaderText = "Movido por";
            


            tablaTransferencia.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Transferencia objNegocio = new N_Transferencia();
            tablaTransferencia.DataSource = objNegocio.ListandoTransferencia1(buscar);
        }
        private void txtBuscar_GotFocus(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "IdPropiedad")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtBuscar_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "IdPropiedad";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            mostrarBuscarTabla(txtBuscar.Text);
        }
        private void limpiarCajas()
        {
            txtIdProducto.Text = "";
            txtIdPropiedad.Text = "";
            txtCantidad.Text = "";
            tablaTransferencia.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            limpiarCajas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaTransferencia.SelectedRows.Count > 0)
            {
                Editarse = true;
                txtIdProducto.Text = tablaTransferencia.CurrentRow.Cells[1].Value.ToString();
                txtIdPropiedad.Text = tablaTransferencia.CurrentRow.Cells[2].Value.ToString();
                txtCantidad.Text = tablaTransferencia.CurrentRow.Cells[3].Value.ToString();
                dtpFecha_Compra.Value = Convert.ToDateTime(tablaTransferencia.CurrentRow.Cells[4].Value.ToString());

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private bool AreTextBoxesFilled(TextBox textBox1, TextBox textBox2, TextBox textBox3)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Porfavor entre un valor en el " + textBox1.Name + " textbox");
                return false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Porfavor entre un valor en el " + textBox2.Name + " textbox");
                return false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Porfavor entre un valor en el  " + textBox3.Name + " textbox");
                return false;
            }
            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesFilled(txtIdProducto, txtIdPropiedad, txtCantidad))
            {
                if (Editarse == false)
                {
                    try
                    {
                        objEntidad.IdProducto = Convert.ToInt32(txtIdProducto.Text);
                        objEntidad.IdPropiedad = Convert.ToInt32(txtIdPropiedad.Text);
                        objEntidad.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        objEntidad.Fecha = dtpFecha_Compra.Value;
                        objEntidad.Movido_Por = _usuario.IdUsuario;


                        objNegocio.InsertandoTransferencia(objEntidad);

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
                        objEntidad.IdTransferencia = Convert.ToInt32(tablaTransferencia.CurrentRow.Cells[0].Value);
                        objEntidad.IdProducto = Convert.ToInt32(txtIdProducto.Text);
                        objEntidad.IdPropiedad = Convert.ToInt32(txtIdPropiedad.Text);
                        objEntidad.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        objEntidad.Fecha = dtpFecha_Compra.Value;
                        objEntidad.Movido_Por = _usuario.IdUsuario;

                        objNegocio.EditandoTransferencia(objEntidad);

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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaTransferencia.SelectedRows.Count > 0)
            {
                objEntidad.IdTransferencia = Convert.ToInt32(tablaTransferencia.CurrentRow.Cells[0].Value);
                objNegocio.EliminandoTransferencia(objEntidad);

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
            if (tablaTransferencia.Rows.Count > 0)

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
                            var pageSize = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A4.Height, iTextSharp.text.PageSize.A4.Width);

                            PdfPTable pTable = new PdfPTable(tablaTransferencia.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in tablaTransferencia.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in tablaTransferencia.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(pageSize, 16f, 16f, 8f, 8f);

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
                    DataTable dt = Excel.DataGridView_To_Datatable(tablaTransferencia);
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
