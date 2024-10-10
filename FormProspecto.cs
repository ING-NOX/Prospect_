using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CODIGO
{
    public partial class FormProspecto : Form
    {
        private int id2;
        private TextBox txtNombre2;
        private TextBox txtPrimerApellido2;
        private TextBox txtSegundoApellido2;
        private TextBox txtCalle2;
        private TextBox txtNumero2;
        private TextBox txtColonia2;
        private TextBox txtCodigoPostal2;
        private TextBox txtTelefono2;
        private TextBox txtRFC2;
        private ComboBox cmbEstatus2;
        private TextBox txtObservaciones2;
        private ListBox listBoxDocumentos2;
        
        private Button btnGuardar2;

        public FormProspecto(int id)
        {
            InitializeComponent();
            this.id2 = id;
            CreateFormControls();
            CargarDatos();
        }

        private void InitializeComponent()
        {
            this.Text = "Visualizar Datos";
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void CreateFormControls()
        {
            
            Label lblNombre2 = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 30), Width = 100 };
            Label lblPrimerApellido2 = new Label { Text = "Primer Apellido:", Location = new System.Drawing.Point(20, 70), Width = 100 };
            Label lblSegundoApellido2 = new Label { Text = "Segundo Apellido:", Location = new System.Drawing.Point(20, 110), Width = 100 };
            Label lblCalle2 = new Label { Text = "Calle:", Location = new System.Drawing.Point(20, 150), Width = 100 };
            Label lblNumero2 = new Label { Text = "Número:", Location = new System.Drawing.Point(20, 190), Width = 100 };
            Label lblColonia2 = new Label { Text = "Colonia:", Location = new System.Drawing.Point(20, 230), Width = 100 };
            Label lblCodigoPostal2 = new Label { Text = "Código Postal:", Location = new System.Drawing.Point(20, 270), Width = 100 };
            Label lblTelefono2 = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 310), Width = 100 };
            Label lblRFC2 = new Label { Text = "RFC:", Location = new System.Drawing.Point(20, 350), Width = 100 };
            Label lblEstatus2 = new Label { Text = "Estatus:", Location = new System.Drawing.Point(20, 390), Width = 100 };
            Label lblObservaciones2 = new Label { Text = "Observaciones:", Location = new System.Drawing.Point(20, 430), Width = 100 };
            Label lblDocumentos2 = new Label { Text = "Documentos:", Location = new System.Drawing.Point(20, 490), Width = 100 }; 

            txtNombre2 = new TextBox { Location = new System.Drawing.Point(130, 30), Width = 240, ReadOnly = true };
            txtPrimerApellido2 = new TextBox { Location = new System.Drawing.Point(130, 70), Width = 240, ReadOnly = true };
            txtSegundoApellido2 = new TextBox { Location = new System.Drawing.Point(130, 110), Width = 240, ReadOnly = true };
            txtCalle2 = new TextBox { Location = new System.Drawing.Point(130, 150), Width = 240, ReadOnly = true };
            txtNumero2 = new TextBox { Location = new System.Drawing.Point(130, 190), Width = 240, ReadOnly = true };
            txtColonia2 = new TextBox { Location = new System.Drawing.Point(130, 230), Width = 240, ReadOnly = true };
            txtCodigoPostal2 = new TextBox { Location = new System.Drawing.Point(130, 270), Width = 240, ReadOnly = true };
            txtTelefono2 = new TextBox { Location = new System.Drawing.Point(130, 310), Width = 240, ReadOnly = true };
            txtRFC2 = new TextBox { Location = new System.Drawing.Point(130, 350), Width = 240, ReadOnly = true };

            cmbEstatus2 = new ComboBox { Location = new System.Drawing.Point(130, 390), Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEstatus2.Items.AddRange(new string[] { "Enviado", "Autorizado", "Rechazado" });
            cmbEstatus2.Enabled = false;

            txtObservaciones2 = new TextBox { Location = new System.Drawing.Point(130, 430), Width = 240, Height = 50, Multiline = true };

            listBoxDocumentos2 = new ListBox { Location = new System.Drawing.Point(130, 490), Width = 240, Height = 60 };

            btnGuardar2 = new Button { Text = "Guardar Cambios", Location = new System.Drawing.Point(130, 560), Width = 100 };
            btnGuardar2.Click += BtnGuardar_Click;

            this.Controls.Add(lblNombre2);
            this.Controls.Add(txtNombre2);
            this.Controls.Add(lblPrimerApellido2);
            this.Controls.Add(txtPrimerApellido2);
            this.Controls.Add(lblSegundoApellido2);
            this.Controls.Add(txtSegundoApellido2);
            this.Controls.Add(lblCalle2);
            this.Controls.Add(txtCalle2);
            this.Controls.Add(lblNumero2);
            this.Controls.Add(txtNumero2);
            this.Controls.Add(lblColonia2);
            this.Controls.Add(txtColonia2);
            this.Controls.Add(lblCodigoPostal2);
            this.Controls.Add(txtCodigoPostal2);
            this.Controls.Add(lblTelefono2);
            this.Controls.Add(txtTelefono2);
            this.Controls.Add(lblRFC2);
            this.Controls.Add(txtRFC2);
            this.Controls.Add(lblEstatus2);
            this.Controls.Add(cmbEstatus2);
            this.Controls.Add(lblObservaciones2);
            this.Controls.Add(txtObservaciones2);
            this.Controls.Add(lblDocumentos2); 
            this.Controls.Add(listBoxDocumentos2); 
            this.Controls.Add(btnGuardar2);
        }

        private void CargarDatos()
        {
            using (var connection = new SqlConnection(@"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;"))
            {
                string query = "SELECT * FROM usuarios WHERE id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id2);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        txtNombre2.Text = row["nombre"].ToString();
                        txtPrimerApellido2.Text = row["primer_apellido"].ToString();
                        txtSegundoApellido2.Text = row["segundo_apellido"].ToString();
                        txtCalle2.Text = row["calle"].ToString();
                        txtNumero2.Text = row["numero"].ToString();
                        txtColonia2.Text = row["colonia"].ToString();
                        txtCodigoPostal2.Text = row["cp"].ToString();
                        txtTelefono2.Text = row["telefono"].ToString();
                        txtRFC2.Text = row["rfc"].ToString();
                        cmbEstatus2.SelectedItem = row["estatus"].ToString();
                        txtObservaciones2.Text = GetMotivoRechazo(id2);
                                             
                        CargarDocumento(id2);

                        string estatus = cmbEstatus2.SelectedItem.ToString();
                        if (estatus == "Enviado")
                        {
                            cmbEstatus2.Enabled = false;
                            txtObservaciones2.Enabled = false;
                            btnGuardar2.Enabled = false;
                        }
                        else
                        {
                            cmbEstatus2.Enabled = false;
                            txtObservaciones2.Enabled = false;
                            btnGuardar2.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetMotivoRechazo(int usuarioId)
        {
            using (var connection = new SqlConnection(@"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;"))
            {
                string query = "SELECT motivo FROM Rechazos WHERE usuario_id = @usuario_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usuario_id", usuarioId);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "";
                }
            }
        }
        
        private void CargarDocumento(int usuarioId)
        {
            using (var connection = new SqlConnection(@"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;"))
            {
                string query = "SELECT documento FROM usuarios WHERE Id = @usuarioId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usuarioId", usuarioId);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        byte[] documento = (byte[])result;
                       
                    }
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEstatus2.SelectedItem.ToString() == "Enviado")
            {
                MessageBox.Show("Debes seleccionar un estatus diferente a Enviado antes de guardar.");
                return;
            }

            using (var connection = new SqlConnection(@"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;"))
            {
                string updateQuery = "UPDATE usuarios SET estatus = @estatus WHERE id = @id";
                using (var command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@estatus", cmbEstatus2.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@id", id2);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
      
                if (cmbEstatus2.SelectedItem.ToString() == "Rechazado")
                {
                    string insertQuery = "INSERT INTO Rechazos (usuario_id, motivo) VALUES (@usuario_id, @motivo)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@usuario_id", id2);
                        command.Parameters.AddWithValue("@motivo", txtObservaciones2.Text);
                        command.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Cambios guardados exitosamente.");
            cmbEstatus2.Enabled = false;
        }
    }
}
