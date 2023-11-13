using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
namespace Proyecto
{
    public partial class ListReportClientes : Form
    {
        public ListReportClientes()
        {
            InitializeComponent();
        }
        E_Clientes objEntidad = new E_Clientes();
        N_Clientes objNegocio = new N_Clientes();
        private void ListReportClientes_Load(object sender, EventArgs e)
        {
            N_Clientes objNegocio = new N_Clientes();
            clientesBindingSource.DataSource = objNegocio.ListandoClientes("");


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            // Create a new SqlConnection and open it
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
            connection.Open();

            // Create a new SqlCommand with a parameterized query
            string query = "select * from Clientes where Fecha_Creado between @FechaInicio and @FechaFinal";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FechaInicio", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@FechaFinal", dateTimePicker2.Value);

            // Create a new SqlDataAdapter with the command
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Create a new DataTable
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the data from the database using the adapter
            adapter.Fill(dataTable);

            // Set the DataSource of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;

            // Close the connection
            connection.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // Create a new SqlConnection and open it
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
            connection.Open();

            // Create a new SqlCommand with a parameterized query
            string query = "select * from Clientes where Fecha_Creado between @FechaInicio and @FechaFinal";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FechaInicio", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@FechaFinal", dateTimePicker2.Value);

            // Create a new SqlDataAdapter with the command
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Create a new DataTable
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the data from the database using the adapter
            adapter.Fill(dataTable);

            // Set the DataSource of the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;

            // Close the connection
            connection.Close();
        }

        private void FacBTN_Click(object sender, EventArgs e)
        {
            ReportClientes frm = new ReportClientes(dateTimePicker1.Value, dateTimePicker2.Value);
            frm.ShowDialog();
        }
    }
}
