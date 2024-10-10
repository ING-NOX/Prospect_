namespace CODIGO;
//to run dotnet run
partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(300, 300);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Text = "Form1";

        this.BackColor = System.Drawing.Color.FromArgb(189, 219, 237);

        System.Windows.Forms.Button register = new System.Windows.Forms.Button();
        register.Text = "Registro";
        register.Location = new System.Drawing.Point(100, 80);
        register.Size = new System.Drawing.Size(100, 50);
        register.BackColor = System.Drawing.Color.White;
        register.Font = new System.Drawing.Font(register.Font, System.Drawing.FontStyle.Bold);
        register.Click += new System.EventHandler(this.Register_Click);
        this.Controls.Add(register);

        System.Windows.Forms.Button ProspectList = new System.Windows.Forms.Button();
        ProspectList.Text = "Lista";
        ProspectList.Location = new System.Drawing.Point(100, 150);
        ProspectList.Size = new System.Drawing.Size(100, 50);
        ProspectList.BackColor = System.Drawing.Color.White;
        ProspectList.Font = new System.Drawing.Font(ProspectList.Font, System.Drawing.FontStyle.Bold);
        ProspectList.Click += new System.EventHandler(this.ProspectList_Click);
        this.Controls.Add(ProspectList);

    }
    #endregion

    private void Register_Click(object sender, EventArgs e)
{
    FormRegistro formRegistro = new FormRegistro();
    //formRegistro.Show();
    this.Hide();
            formRegistro.FormClosed += (s, args) => this.Show();
            formRegistro.ShowDialog();
}

private void ProspectList_Click(object sender, EventArgs e)
{
    FormLista formLista = new FormLista();
    //formLista.Show();
    this.Hide();
            formLista.FormClosed += (s, args) => this.Show();
            formLista.ShowDialog();
}
    
}

