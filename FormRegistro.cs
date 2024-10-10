using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CODIGO
{
    public partial class FormRegistro : Form
    {
        private List<string> archivosSeleccionados = new List<string>();
        private TextBox txtNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private TextBox txtCalle;
        private TextBox txtNumero;
        private TextBox txtColonia;
        private TextBox txtCodigoPostal;
        private TextBox txtTelefono;
        private TextBox txtRFC;
        private Label lbdocumentos;
        private Button btnSeleccionarArchivos;
        private Button btnSalir;  
        private Button btnEnviar;
        private Label lblNombre;
        private Label lblPrimerApellido;
        private Label lblSegundoApellido;
        private Label lblCalle;
        private Label lblNumero;
        private Label lblColonia;
        private Label lblCodigoPostal;
        private Label lblTelefono;
        private Label lblRFC;

        public FormRegistro()
        {
            InitializeComponent();
            CreateFormControls();
        }

        private void InitializeComponent()
        {
            this.Text = "Registro";
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void CreateFormControls()
        {
            
            lblNombre = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 30), Width = 100 };
            lblPrimerApellido = new Label { Text = "Primer Apellido:", Location = new System.Drawing.Point(20, 70), Width = 100 };
            lblSegundoApellido = new Label { Text = "Segundo Apellido:", Location = new System.Drawing.Point(20, 110), Width = 100 };
            lblCalle = new Label { Text = "Calle:", Location = new System.Drawing.Point(20, 150), Width = 100 };
            lblNumero = new Label { Text = "Número:", Location = new System.Drawing.Point(20, 190), Width = 100 };
            lblColonia = new Label { Text = "Colonia:", Location = new System.Drawing.Point(20, 230), Width = 100 };
            lblCodigoPostal = new Label { Text = "Código Postal:", Location = new System.Drawing.Point(20, 270), Width = 100 };
            lblTelefono = new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 310), Width = 100 };
            lblRFC = new Label { Text = "RFC:", Location = new System.Drawing.Point(20, 350), Width = 100 };
            lbdocumentos = new Label { Text = "Documentos:",Location = new System.Drawing.Point(20, 390), Width = 240 };

     
            //OnlyAllowNumbers = solo acepta numeros
            txtNombre = new TextBox { Location = new System.Drawing.Point(130, 30), Width = 240 };
            txtPrimerApellido = new TextBox { Location = new System.Drawing.Point(130, 70), Width = 240 };
            txtSegundoApellido = new TextBox { Location = new System.Drawing.Point(130, 110), Width = 240 };
            txtCalle = new TextBox { Location = new System.Drawing.Point(130, 150), Width = 240 };
            txtNumero = new TextBox { Location = new System.Drawing.Point(130, 190), Width = 240 };
            txtNumero.KeyPress += OnlyAllowNumbers;

            txtColonia = new TextBox { Location = new System.Drawing.Point(130, 230), Width = 240 };
            txtCodigoPostal = new TextBox { Location = new System.Drawing.Point(130, 270), Width = 240 };
            txtCodigoPostal.KeyPress += OnlyAllowNumbers; 

            txtTelefono = new TextBox { Location = new System.Drawing.Point(130, 310), Width = 240 };
            txtTelefono.KeyPress += OnlyAllowNumbers; 

            txtRFC = new TextBox { Location = new System.Drawing.Point(130, 350), Width = 240 };
            
            
            btnSeleccionarArchivos = new Button { Text = "Seleccionar Archivos", Location = new System.Drawing.Point(100, 385), Width = 150 };
            btnSeleccionarArchivos.Click += BtnSeleccionarArchivos_Click;
           
            btnSalir = new Button { Text = "Salir", Location = new System.Drawing.Point(195,420), Width = 160 };
            btnSalir.Click += BtnSalir_Click;
            
            btnSalir = new Button { Text = "Salir",Location = new System.Drawing.Point(195, 420), Width = 160, BackColor = System.Drawing.Color.FromArgb(169, 4, 4), ForeColor = System.Drawing.Color.White };
            btnSalir.Click += BtnSalir_Click;

            btnEnviar = new Button { Text = "Enviar", Location = new System.Drawing.Point(20, 420), Width = 160 };
            btnEnviar.Click += BtnEnviar_Click;


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
            this.Controls.Add(btnSeleccionarArchivos);
            this.Controls.Add(btnSalir);
            this.Controls.Add(btnEnviar);
            this.Controls.Add(lbdocumentos);
        }

        private void OnlyAllowNumbers(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnSeleccionarArchivos_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar Archivos";
            openFileDialog.Multiselect = true; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                archivosSeleccionados.Clear(); 
                archivosSeleccionados.AddRange(openFileDialog.FileNames);
                MessageBox.Show($"Archivos seleccionados: {string.Join(", ", archivosSeleccionados)}");
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
       {
         
          string message;
          MessageBoxIcon icon;

         if (IsAnyFieldFilled())
         {
           message = "¿Está seguro que desea salir? Se perderán los datos capturados.";
           icon = MessageBoxIcon.Warning; 
          }
          else
           {
            message = "¿Está seguro que desea salir?";
            icon = MessageBoxIcon.Information; 
           }
          
            var result = MessageBox.Show(message, "Confirmar Salida", MessageBoxButtons.YesNo, icon);
            if (result == DialogResult.Yes)
             {
               this.Close();
             }
       }

       private byte[] LeerArchivo(string ruta)
        {
          return System.IO.File.ReadAllBytes(ruta);
        }

       private void BtnEnviar_Click(object sender, EventArgs e)
       {
        if (AreAllFieldsFilled())
    {
        
        if (InsertarDatos())
        {
            MessageBox.Show("Datos enviados correctamente.");
            LimpiarCampos();
        }
        else
        {
            MessageBox.Show("Error al enviar los datos. Inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    else
    {
        MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
       }

    private bool InsertarDatos()
{
    
    using (var connection = new Connection().AbrirConexion())
    {
        
        if (connection != null)
        {
            
            string query = "INSERT INTO usuarios (nombre, primer_apellido, segundo_apellido, calle, numero, colonia, cp, telefono, rfc, documento) " +
                           "VALUES (@nombre, @primer_apellido, @segundo_apellido, @calle, @numero, @colonia, @cp, @telefono, @rfc, @documento)";

            using (var command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@primer_apellido", txtPrimerApellido.Text);
                command.Parameters.AddWithValue("@segundo_apellido", txtSegundoApellido.Text);
                command.Parameters.AddWithValue("@calle", txtCalle.Text);
                command.Parameters.AddWithValue("@numero", txtNumero.Text);
                command.Parameters.AddWithValue("@colonia", txtColonia.Text);
                command.Parameters.AddWithValue("@cp", txtCodigoPostal.Text);
                command.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                command.Parameters.AddWithValue("@rfc", txtRFC.Text);

                if (archivosSeleccionados.Count > 0)
                {
                    byte[] documento = LeerArchivo(archivosSeleccionados[0]);
                    command.Parameters.AddWithValue("@documento", documento);
                }
                else
                {
                    command.Parameters.AddWithValue("@documento", DBNull.Value);
                }

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        return false; 
    }
}

        private bool IsAnyFieldFilled()
        {
            
            return !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   !string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
                   !string.IsNullOrWhiteSpace(txtSegundoApellido.Text) ||
                   !string.IsNullOrWhiteSpace(txtCalle.Text) ||
                   !string.IsNullOrWhiteSpace(txtNumero.Text) ||
                   !string.IsNullOrWhiteSpace(txtColonia.Text) ||
                   !string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ||
                   !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                   !string.IsNullOrWhiteSpace(txtRFC.Text);
        }
        private bool AreAllFieldsFilled()
        {
    
           return !string.IsNullOrWhiteSpace(txtNombre.Text) &&
           !string.IsNullOrWhiteSpace(txtPrimerApellido.Text) &&
           !string.IsNullOrWhiteSpace(txtSegundoApellido.Text) &&
           !string.IsNullOrWhiteSpace(txtCalle.Text) &&
           !string.IsNullOrWhiteSpace(txtNumero.Text) &&
           !string.IsNullOrWhiteSpace(txtColonia.Text) &&
           !string.IsNullOrWhiteSpace(txtCodigoPostal.Text) &&
           !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
           !string.IsNullOrWhiteSpace(txtRFC.Text);
}

private void LimpiarCampos()
{
    txtNombre.Clear();
    txtPrimerApellido.Clear();
    txtSegundoApellido.Clear();
    txtCalle.Clear();
    txtNumero.Clear();
    txtColonia.Clear();
    txtCodigoPostal.Clear();
    txtTelefono.Clear();
    txtRFC.Clear();
}

    }
 
}

