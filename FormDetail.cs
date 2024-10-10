using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CODIGO
{
    public partial class FormDetail : Form
    {
        private int id;
        private TextBox txtNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private TextBox txtCalle;
        private TextBox txtNumero;
        private TextBox txtColonia;
        private TextBox txtCodigoPostal;
        private TextBox txtTelefono;
        private TextBox txtRFC;
        private ComboBox cmbEstatus;
        private TextBox txtObservaciones;
        private ListBox listBoxDocumentos;
        
        private Button btnGuardar;

        public FormDetail(int id)
        {
            InitializeComponent();
            this.id = id;
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
            // Crear y configurar etiquetas
            Label lblNombre = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 30), Width = 100 };
            Label lblPrimerApellido = new Label { Text = "Primer Apellido:", Location = new System.Drawing.Point(20, 70), Width = 100 };
            Label lblSegundoApellido = new Label { Text = "Segundo Apellido:", Location = new System.Drawing.Point(20, 110), Width = 100 };
            Label lblCalle = new Label { Text = "Calle:", Location = new System.Drawing.Point(20, 150), Width = 100 };
            Label lblNumero = new Label { Text = "Número:", Location = new System.Drawing.Point(20, 190), Width = 100 };
            Label lblColonia = new Label { Text = "Colonia:", Location = new System.Drawing.Point(20, 230), Width = 100 };
            Label lblCodigoPostal = new Label { Text = "Código Postal:", Location = new System.Drawing.Point(20, 270), Width = 100 };
            Label lblTelefono = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 310), Width = 100 };
            Label lblRFC = new Label { Text = "RFC:", Location = new System.Drawing.Point(20, 350), Width = 100 };
            Label lblEstatus = new Label { Text = "Estatus:", Location = new System.Drawing.Point(20, 390), Width = 100 };
            Label lblObservaciones = new Label { Text = "Observaciones:", Location = new System.Drawing.Point(20, 430), Width = 100 };
            Label lblDocumentos = new Label { Text = "Documentos:", Location = new System.Drawing.Point(20, 490), Width = 100 }; 

            txtNombre = new TextBox { Location = new System.Drawing.Point(130, 30), Width = 240, ReadOnly = true };
            txtPrimerApellido = new TextBox { Location = new System.Drawing.Point(130, 70), Width = 240, ReadOnly = true };
            txtSegundoApellido = new TextBox { Location = new System.Drawing.Point(130, 110), Width = 240, ReadOnly = true };
            txtCalle = new TextBox { Location = new System.Drawing.Point(130, 150), Width = 240, ReadOnly = true };
            txtNumero = new TextBox { Location = new System.Drawing.Point(130, 190), Width = 240, ReadOnly = true };
            txtColonia = new TextBox { Location = new System.Drawing.Point(130, 230), Width = 240, ReadOnly = true };
            txtCodigoPostal = new TextBox { Location = new System.Drawing.Point(130, 270), Width = 240, ReadOnly = true };
            txtTelefono = new TextBox { Location = new System.Drawing.Point(130, 310), Width = 240, ReadOnly = true };
            txtRFC = new TextBox { Location = new System.Drawing.Point(130, 350), Width = 240, ReadOnly = true };

            cmbEstatus = new ComboBox { Location = new System.Drawing.Point(130, 390), Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEstatus.Items.AddRange(new string[] { "Enviado", "Autorizado", "Rechazado" });
            cmbEstatus.Enabled = false;

            txtObservaciones = new TextBox { Location = new System.Drawing.Point(130, 430), Width = 240, Height = 50, Multiline = true };

            listBoxDocumentos = new ListBox { Location = new System.Drawing.Point(130, 490), Width = 240, Height = 60 };

            btnGuardar = new Button { Text = "Guardar Cambios", Location = new System.Drawing.Point(130, 560), Width = 100 };
            btnGuardar.Click += BtnGuardar_Click;

 
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblPrimerApellido);
            this.Controls.Add(txtPrimerApellido);
            this.Controls.Add(lblSegundoApellido);
            this.Controls.Add(txtSegundoApellido);
            this.Controls.Add(lblCalle);
            this.Controls.Add(txtCalle);
            this.Controls.Add(lblNumero);
            this.Controls.Add(txtNumero);
            this.Controls.Add(lblColonia);
            this.Controls.Add(txtColonia);
            this.Controls.Add(lblCodigoPostal);
            this.Controls.Add(txtCodigoPostal);
            this.Controls.Add(lblTelefono);
            this.Controls.Add(txtTelefono);
            this.Controls.Add(lblRFC);
            this.Controls.Add(txtRFC);
            this.Controls.Add(lblEstatus);
            this.Controls.Add(cmbEstatus);
            this.Controls.Add(lblObservaciones);
            this.Controls.Add(txtObservaciones);
            this.Controls.Add(lblDocumentos); 
            this.Controls.Add(listBoxDocumentos); 
            this.Controls.Add(btnGuardar);
        }

        private void CargarDatos()
        {
            using (var connection = new SqlConnection(@"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;"))
            {
                string query = "SELECT * FROM usuarios WHERE id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        txtNombre.Text = row["nombre"].ToString();
                        txtPrimerApellido.Text = row["primer_apellido"].ToString();
                        txtSegundoApellido.Text = row["segundo_apellido"].ToString();
                        txtCalle.Text = row["calle"].ToString();
                        txtNumero.Text = row["numero"].ToString();
                        txtColonia.Text = row["colonia"].ToString();
                        txtCodigoPostal.Text = row["cp"].ToString();
                        txtTelefono.Text = row["telefono"].ToString();
                        txtRFC.Text = row["rfc"].ToString();
                        cmbEstatus.SelectedItem = row["estatus"].ToString();
                        txtObservaciones.Text = GetMotivoRechazo(id);
                                             
                        //CargarDocumentos(id);
                        CargarDocumento(id);

                        string estatus = cmbEstatus.SelectedItem.ToString();
                        if (estatus == "Enviado")
                        {
                            cmbEstatus.Enabled = true;
                            txtObservaciones.Enabled = true;
                        }
                        else
                        {
                            cmbEstatus.Enabled = false;
                            txtObservaciones.Enabled = false;
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

        private void CargarDocumentos(int usuarioId)
        {
            using (var connection = new SqlConnection(@"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;"))
            {
                string query = "SELECT nombre_documento FROM Documentos WHERE usuario_id = @usuario_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usuario_id", usuarioId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBoxDocumentos.Items.Add(reader["nombre_documento"].ToString());
                        }
                    }
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
            if (cmbEstatus.SelectedItem.ToString() == "Enviado")
            {
                MessageBox.Show("Debes seleccionar un estatus diferente a Enviado antes de guardar.");
                return;
            }

            using (var connection = new SqlConnection(@"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;"))
            {
                string updateQuery = "UPDATE usuarios SET estatus = @estatus WHERE id = @id";
                using (var command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@estatus", cmbEstatus.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
      
                if (cmbEstatus.SelectedItem.ToString() == "Rechazado")
                {
                    string insertQuery = "INSERT INTO Rechazos (usuario_id, motivo) VALUES (@usuario_id, @motivo)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@usuario_id", id);
                        command.Parameters.AddWithValue("@motivo", txtObservaciones.Text);
                        command.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Cambios guardados exitosamente.");
            cmbEstatus.Enabled = false;
        }
    }
}
