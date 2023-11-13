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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Proyecto
{
    public partial class FrmUsuarios : Form
    {
        E_Usuarios _usuario = new E_Usuarios();
        public FrmUsuarios(E_Usuarios usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.tablaUsuarios.DefaultCellStyle.ForeColor = Color.Black;



        }
        private string idUsuarios;
        private bool Editarse = false, Estado = true;
        string sexo;
        int rol;

        E_Usuarios objEntidad = new E_Usuarios();
        N_Usuarios objNegocio = new N_Usuarios();




        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
            txtBuscar_LostFocus(this, e);

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
        public void accionesTabla()
        {

            tablaUsuarios.Columns[0].Visible = false;
            tablaUsuarios.Columns[1].HeaderText = "Username";
            tablaUsuarios.Columns[2].HeaderText = "Password";
            tablaUsuarios.Columns[3].HeaderText = "Nombre";
            tablaUsuarios.Columns[4].HeaderText = "Apellido";
            tablaUsuarios.Columns[5].HeaderText = "Email";
            tablaUsuarios.Columns[6].HeaderText = "Telefono";
            tablaUsuarios.Columns[7].HeaderText = "Sexo";
            tablaUsuarios.Columns[8].HeaderText = "Fecha de Nacimiento";
            tablaUsuarios.Columns[9].HeaderText = "Fecha de Contrato";
            tablaUsuarios.Columns[10].HeaderText = "Fecha de Creacion de Cuenta";
            tablaUsuarios.Columns[11].HeaderText = "Activo";
            tablaUsuarios.Columns[12].HeaderText = "Estado";
            tablaUsuarios.Columns[13].HeaderText = "Rol";
            tablaUsuarios.Columns[14].HeaderText = "Creado Por";


            tablaUsuarios.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_Usuarios objNegocio = new N_Usuarios();
            tablaUsuarios.DataSource = objNegocio.ListandoUsuarios(buscar);
        }
        private void txtBuscar_GotFocus(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Nombre")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtBuscar_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Nombre";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            mostrarBuscarTabla(txtBuscar.Text);
        }
        private void limpiarCajas()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            tablaUsuarios.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            limpiarCajas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaUsuarios.SelectedRows.Count > 0)
            {
                Editarse = true;
                txtUsername.Text = tablaUsuarios.CurrentRow.Cells[1].Value.ToString();
                txtPassword.Text = tablaUsuarios.CurrentRow.Cells[2].Value.ToString();
                txtNombre.Text = tablaUsuarios.CurrentRow.Cells[3].Value.ToString();
                txtApellido.Text = tablaUsuarios.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = tablaUsuarios.CurrentRow.Cells[5].Value.ToString();
                txtTelefono.Text = tablaUsuarios.CurrentRow.Cells[6].Value.ToString();
                Fecha_Nacimiento_dtp.Value = Convert.ToDateTime(tablaUsuarios.CurrentRow.Cells[8].Value.ToString());
                Fecha_Contrato_dtp.Value = Convert.ToDateTime(tablaUsuarios.CurrentRow.Cells[9].Value.ToString());
                Fecha_Registro_dtp.Value = Convert.ToDateTime(tablaUsuarios.CurrentRow.Cells[10].Value.ToString());
                if(tablaUsuarios.CurrentRow.Cells[11].Value.ToString() == "1")
                {
                    RolCB.SelectedItem = "Administrador";
                }
                else
                {
                    RolCB.SelectedItem = "Empleado";
                }

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private bool AreTextBoxesFilled(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6)
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
                MessageBox.Show("Porfavor entre un valor en el " + textBox3.Name + " textbox");
                return false;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Porfavor entre un valor en el " + textBox4.Name + " textbox");
                return false;
            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Porfavor entre un valor en el " + textBox5.Name + " textbox");
                return false;
            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Porfavor entre un valor en el " + textBox6.Name + " textbox");
                return false;
            }
            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesFilled(txtUsername, txtPassword, txtNombre, txtApellido, txtEmail, txtTelefono))
            {
                if (Editarse == false)
                {
                    try
                    {
                        objEntidad.Username = txtUsername.Text;
                        objEntidad.Passwrd = txtPassword.Text;
                        objEntidad.Nombre = txtNombre.Text;
                        objEntidad.Apellido = txtApellido.Text;
                        objEntidad.Email = txtEmail.Text;
                        objEntidad.Telefono = txtTelefono.Text;
                        objEntidad.Sexo = sexo;
                        objEntidad.Fecha_Nacimiento = Fecha_Nacimiento_dtp.Value;
                        objEntidad.Fecha_Contrato = Fecha_Contrato_dtp.Value;
                        objEntidad.Fecha_Creacion_Cuenta = Fecha_Registro_dtp.Value;
                        objEntidad.Activo = false;
                        objEntidad.Estado = Estado;
                        objEntidad.Rol = rol;
                        objEntidad.Creado_Por = _usuario.IdUsuario;

                        objNegocio.InsertandoUsuarios(objEntidad);

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
                        objEntidad.IdUsuario = Convert.ToInt32(tablaUsuarios.CurrentRow.Cells[0].Value);
                        objEntidad.Username = txtUsername.Text;
                        objEntidad.Passwrd = txtPassword.Text;
                        objEntidad.Nombre = txtNombre.Text;
                        objEntidad.Apellido = txtApellido.Text;
                        objEntidad.Email = txtEmail.Text;
                        objEntidad.Telefono = txtTelefono.Text;
                        objEntidad.Sexo = sexo;
                        objEntidad.Fecha_Nacimiento = Fecha_Nacimiento_dtp.Value;
                        objEntidad.Fecha_Contrato = Fecha_Contrato_dtp.Value;
                        objEntidad.Fecha_Creacion_Cuenta = Fecha_Registro_dtp.Value;
                        objEntidad.Activo = false;
                        objEntidad.Estado = Estado;
                        objEntidad.Rol = rol;
                        objEntidad.Creado_Por = _usuario.IdUsuario;

                        objNegocio.EditandoUsuarios(objEntidad);

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
            if (tablaUsuarios.SelectedRows.Count > 0)
            {
                objEntidad.IdUsuario = Convert.ToInt32(tablaUsuarios.CurrentRow.Cells[0].Value);
                objNegocio.EliminandoUsuarios(objEntidad);

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
            if (tablaUsuarios.Rows.Count > 0)

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

                            PdfPTable pTable = new PdfPTable(tablaUsuarios.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in tablaUsuarios.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in tablaUsuarios.Rows)

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
                    DataTable dt = Excel.DataGridView_To_Datatable(tablaUsuarios);
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
                sexo = "Masculino";

            }
        }

        private void RolCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RolCB.SelectedItem.ToString() == "Administrador")
            {
                rol = 1;
            }
            else
            {
                rol = 2;
            }
        }

        private void FRB_CheckedChanged(object sender, EventArgs e)
        {
            if (FRB.Checked == true)
            {
                sexo = "Femenino";

            }
        }

        private void ICB_CheckedChanged(object sender, EventArgs e)
        {
            if (ICB.Checked == true)
            {
                ACB.Checked = false;
                Estado = false;
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

        private void ACB_CheckedChanged(object sender, EventArgs e)
        {
            if(ACB.Checked == true)
            {
                ICB.Checked = false;
                Estado = true;
            }
        }
    }
}
