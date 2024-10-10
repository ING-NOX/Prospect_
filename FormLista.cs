using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace CODIGO
{
    public partial class FormLista : Form
    {
        private ListView listView;
        private ComboBox cmbEstatus;
        private Button btnVerDetalles;
        private Button btnProspecto;
        

        public FormLista()
        {
            InitializeComponent();
            CreateListView();
            LoadData("Enviado");
        }

        private void InitializeComponent()
        {
            this.Text = "Lista";
            this.ClientSize = new System.Drawing.Size(750, 300);
           

            cmbEstatus = new ComboBox {Location = new System.Drawing.Point(20, 20), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList};
            cmbEstatus.Items.AddRange(new string[] { "Enviado", "Autorizado", "Rechazado" });
            cmbEstatus.SelectedIndex = 0;
            cmbEstatus.SelectedIndexChanged += CmbEstatus_SelectedIndexChanged;
            this.Controls.Add(cmbEstatus);

            btnVerDetalles = new Button 
    { 
        Text = "Capturados", 
        Location = new System.Drawing.Point(200, 20), 
        Width = 100 
    };
            btnVerDetalles.Click += BtnVerDetalles_Click;
            this.Controls.Add(btnVerDetalles);

            btnProspecto = new Button { Text = "Listar", Location = new System.Drawing.Point(320, 20), Width = 100 };
            btnProspecto.Click += BtnProspecto_Click;
            this.Controls.Add(btnProspecto);

        }

        private void BtnProspecto_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
    {
        
        int idSeleccionado = int.Parse(listView.SelectedItems[0].SubItems[0].Text);

        FormProspecto formDetail = new FormProspecto(idSeleccionado);
        formDetail.ShowDialog();
    }
    else
    {
        MessageBox.Show("Por favor, selecciona un usuario para ver los detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
          
        }

        private void CreateListView()
        {
            
            listView = new ListView
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(700, 200),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Scrollable = true,
            };

            
            listView.Columns.Add("Id", 50);
            listView.Columns.Add("Nombre", 100);
            listView.Columns.Add("Primer Apellido", 200);
            listView.Columns.Add("Segundo Apellido", 200);
            listView.Columns.Add("Estatus", 100);

            this.Controls.Add(listView);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        


        public class Connection
{
    private string connectionString = @"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;";

    public DataTable ObtenerDatos(string estatus)
    {
    DataTable dataTable = new DataTable();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string query = "SELECT * FROM usuarios WHERE estatus = @estatus";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@estatus", estatus);
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }
        }
    }

    return dataTable;
    }
}

 private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estatusSeleccionado = cmbEstatus.SelectedItem.ToString();
            LoadData(estatusSeleccionado); 
                  }


private void LoadData(string estatus)
{
   
    var connection = new Connection();
    DataTable dataTable = connection.ObtenerDatos(estatus);

    listView.Items.Clear();

    foreach (DataRow row in dataTable.Rows)
    {
        var item = new ListViewItem(row["id"].ToString());
        item.SubItems.Add(row["nombre"].ToString());
        item.SubItems.Add(row["primer_apellido"].ToString());
        item.SubItems.Add(row["segundo_apellido"].ToString());
        item.SubItems.Add(row["estatus"].ToString());
        listView.Items.Add(item);
    }
}
private void BtnVerDetalles_Click(object sender, EventArgs e)
{
    
    if (listView.SelectedItems.Count > 0)
    {
        
        int idSeleccionado = int.Parse(listView.SelectedItems[0].SubItems[0].Text);

        FormDetail formDetail = new FormDetail(idSeleccionado);
        formDetail.ShowDialog();
    }
    else
    {
        MessageBox.Show("Por favor, selecciona un usuario para cambiar estatus.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}


    }
}

