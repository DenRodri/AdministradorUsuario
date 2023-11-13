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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Proyecto
{
    public partial class FrmPropiedades : Form
    {
        E_Usuarios _usuario = new E_Usuarios();
        public FrmPropiedades(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.tablaPropiedades.DefaultCellStyle.ForeColor = Color.Black;
            
            

        }
        private bool Editarse = false, disponible = true;

        E_Propiedades objEntidad = new E_Propiedades();
        N_Propiedades objNegocio = new N_Propiedades();


        private void TextBoxNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmPropiedades_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
            txtBuscar_LostFocus(this, e);

        }
        public void accionesTabla()
        {

            tablaPropiedades.Columns[0].HeaderText = "ID";
            tablaPropiedades.Columns[1].HeaderText = "Calle";
            tablaPropiedades.Columns[2].HeaderText = "Sector";
            tablaPropiedades.Columns[3].HeaderText = "Municipio";
            tablaPropiedades.Columns[4].HeaderText = "Provincia";
            tablaPropiedades.Columns[5].HeaderText = "Creador";
            tablaPropiedades.Columns[6].HeaderText = "Baños";
            tablaPropiedades.Columns[7].HeaderText = "Habitaciones";
            tablaPropiedades.Columns[8].HeaderText = "Parqueos";
            tablaPropiedades.Columns[9].HeaderText = "Costo por noche";
            tablaPropiedades.Columns[10].HeaderText = "Oferta";
            tablaPropiedades.Columns[11].HeaderText = "Fecha de compra";
            tablaPropiedades.Columns[12].HeaderText = "Costo de compra";
            tablaPropiedades.Columns[13].HeaderText = "Tipo de casa";
            tablaPropiedades.Columns[14].HeaderText = "Disponible";


            tablaPropiedades.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Propiedades objNegocio = new N_Propiedades();
            tablaPropiedades.DataSource = objNegocio.ListandoPropiedades(buscar);
        }
        private void txtBuscar_GotFocus(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "ID")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = SystemColors.WindowText; 
            }
        }

        private void txtBuscar_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "ID";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
        
            mostrarBuscarTabla(txtBuscar.Text);
        }
        private void limpiarCajas()
        {
            txtCalle.Text = "";
            txtSector.Text = "";
            txtMunicipio.Text = "";
            txtProvincia.Text = "";
            txtCantBath.Text = "";
            txtCantRoom.Text = "";
            txtNumParq.Text = "";
            txtCost.Text = "";
            txtOfert.Text = "";
            txtCosteComp.Text = "";
            tablaPropiedades.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            limpiarCajas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaPropiedades.SelectedRows.Count > 0)
            {
                Editarse = true;
                txtCalle.Text = tablaPropiedades.CurrentRow.Cells[1].Value.ToString();
                txtSector.Text = tablaPropiedades.CurrentRow.Cells[2].Value.ToString();
                txtMunicipio.Text = tablaPropiedades.CurrentRow.Cells[3].Value.ToString();
                txtProvincia.Text = tablaPropiedades.CurrentRow.Cells[4].Value.ToString();
                txtCantBath.Text = tablaPropiedades.CurrentRow.Cells[5].Value.ToString();
                txtCantRoom.Text = tablaPropiedades.CurrentRow.Cells[6].Value.ToString();
                txtNumParq.Text = tablaPropiedades.CurrentRow.Cells[7].Value.ToString();
                txtCost.Text = tablaPropiedades.CurrentRow.Cells[8].Value.ToString();
                txtCosteComp.Text = tablaPropiedades.CurrentRow.Cells[9].Value.ToString();
                txtOfert.Text = tablaPropiedades.CurrentRow.Cells[10].Value.ToString();
                dtpFecha_Compra.Value = Convert.ToDateTime(tablaPropiedades.CurrentRow.Cells[11].Value.ToString());
                txtCosteComp.Text = tablaPropiedades.CurrentRow.Cells[12].Value.ToString();
                TipoCB.SelectedItem = tablaPropiedades.CurrentRow.Cells[13].Value.ToString();

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
                    objEntidad.Calle = txtCalle.Text;
                    objEntidad.Sector = txtSector.Text;
                    objEntidad.Municipio = txtMunicipio.Text;
                    objEntidad.Provincia = txtProvincia.Text;
                    objEntidad.Creado_por = _usuario.IdUsuario;
                    objEntidad.CantBathroom = Convert.ToInt32(txtCantBath.Text);
                    objEntidad.CantRooms = Convert.ToInt32(txtCantRoom.Text);
                    objEntidad.NumeroParqueo = Convert.ToInt32(txtNumParq.Text);
                    objEntidad.Costo_Noche = Convert.ToDecimal(txtCost.Text);
                    objEntidad.Oferta = Convert.ToInt32(txtOfert.Text);
                    objEntidad.Fecha_Compra = dtpFecha_Compra.Value;
                    objEntidad.Compro_Costo = Convert.ToDecimal(txtCosteComp.Text);
                    objEntidad.TipoCasa = TipoCB.SelectedItem.ToString();
                    objEntidad.Disponible = disponible;

                    objNegocio.InsertandoPropiedades(objEntidad);

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
                    objEntidad.IdPropiedad = Convert.ToInt32(tablaPropiedades.CurrentRow.Cells[0].Value);
                    objEntidad.Calle = txtCalle.Text;
                    objEntidad.Sector = txtSector.Text;
                    objEntidad.Municipio = txtMunicipio.Text;
                    objEntidad.Provincia = txtProvincia.Text;
                    objEntidad.Creado_por = _usuario.IdUsuario;
                    objEntidad.CantBathroom = Convert.ToInt32(txtCantBath.Text);
                    objEntidad.CantRooms = Convert.ToInt32(txtCantRoom.Text);
                    objEntidad.NumeroParqueo = Convert.ToInt32(txtNumParq.Text);
                    objEntidad.Costo_Noche = Convert.ToDecimal(txtCost.Text);
                    objEntidad.Oferta = Convert.ToInt32(txtOfert.Text);
                    objEntidad.Fecha_Compra = dtpFecha_Compra.Value;
                    objEntidad.Compro_Costo = Convert.ToDecimal(txtCosteComp.Text);
                    objEntidad.TipoCasa = TipoCB.SelectedItem.ToString();
                    objEntidad.Disponible = disponible;

                    objNegocio.EditandoPropiedades(objEntidad);

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
            if (tablaPropiedades.SelectedRows.Count > 0)
            {
                objEntidad.IdPropiedad = Convert.ToInt32(tablaPropiedades.CurrentRow.Cells[0].Value);
                objNegocio.EliminandoPropiedades(objEntidad);

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
            if (tablaPropiedades.Rows.Count > 0)

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

                            PdfPTable pTable = new PdfPTable(tablaPropiedades.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in tablaPropiedades.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in tablaPropiedades.Rows)

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
                    DataTable dt = Excel.DataGridView_To_Datatable(tablaPropiedades);
                    dt.exportToExcel(openFileDialog.FileName);
                    MessageBox.Show("Data is exported!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MRB_CheckedChanged(object sender, EventArgs e)
        {
            if (MRB.Checked == true)
            {
                disponible = false;

            }
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
            if (FRB.Checked == true)
            {
                disponible = true;

            }
        }
    }
}
