﻿using CapaEntidades;
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
    public partial class FrmPropiedadResidenciales : Form
    {
        E_Usuarios _usuario = new E_Usuarios();
        public FrmPropiedadResidenciales(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.tablaPropiedadResidenciales.DefaultCellStyle.ForeColor = Color.Black;



        }
        private bool Editarse = false, disponible = true;

        E_PropiedadResidenciales objEntidad = new E_PropiedadResidenciales();
        N_PropiedadResidenciales objNegocio = new N_PropiedadResidenciales();


        private void TextBoxNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmPropiedadResidenciales_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
            txtBuscar_LostFocus(this, e);

        }
        public void accionesTabla()
        {

            tablaPropiedadResidenciales.Columns[0].HeaderText = "IdPropiedad";
            tablaPropiedadResidenciales.Columns[1].HeaderText = "IdResidencial";



            tablaPropiedadResidenciales.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_PropiedadResidenciales objNegocio = new N_PropiedadResidenciales();
            tablaPropiedadResidenciales.DataSource = objNegocio.ListandoPropiedadResidenciales(buscar);
        }
        private void txtBuscar_GotFocus(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "IdResidencial")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtBuscar_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "IdResidencial";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            mostrarBuscarTabla(txtBuscar.Text);
        }
        private void limpiarCajas()
        {
            txtIdPropiedad.Text = "";
            txtIdResidencial.Text = "";

            tablaPropiedadResidenciales.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            limpiarCajas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaPropiedadResidenciales.SelectedRows.Count > 0)
            {
                Editarse = true;
                txtIdPropiedad.Text = tablaPropiedadResidenciales.CurrentRow.Cells[0].Value.ToString();
                txtIdResidencial.Text = tablaPropiedadResidenciales.CurrentRow.Cells[1].Value.ToString();


            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private bool AreTextBoxesFilled(TextBox textBox1, TextBox textBox2)
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
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesFilled(txtIdPropiedad, txtIdResidencial))
            {
                if (Editarse == false)
                {
                    try
                    {
                        objEntidad.IdPropiedad = Convert.ToInt32(txtIdPropiedad.Text);
                        objEntidad.IdResidencial = Convert.ToInt32(txtIdResidencial.Text);

                        objNegocio.InsertandoPropiedadResidenciales(objEntidad);

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
                        objEntidad.IdPropiedad = Convert.ToInt32(txtIdPropiedad.Text);
                        objEntidad.IdResidencial = Convert.ToInt32(txtIdResidencial.Text);

                        objNegocio.EditandoPropiedadResidenciales(objEntidad);

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
            if (tablaPropiedadResidenciales.SelectedRows.Count > 0)
            {
                objEntidad.IdPropiedad = Convert.ToInt32(tablaPropiedadResidenciales.CurrentRow.Cells[0].Value);
                objEntidad.IdResidencial = Convert.ToInt32(tablaPropiedadResidenciales.CurrentRow.Cells[1].Value);
                objNegocio.EliminandoPropiedadResidenciales(objEntidad);

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
            if (tablaPropiedadResidenciales.Rows.Count > 0)

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

                            PdfPTable pTable = new PdfPTable(tablaPropiedadResidenciales.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in tablaPropiedadResidenciales.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in tablaPropiedadResidenciales.Rows)

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
                    DataTable dt = Excel.DataGridView_To_Datatable(tablaPropiedadResidenciales);
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

        private void FRB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
