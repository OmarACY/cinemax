namespace cinemax
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cinemax));
            this.cbCveEmpleados = new System.Windows.Forms.ComboBox();
            this.labelCveEmpleado = new System.Windows.Forms.Label();
            this.labelNombreEmpleado = new System.Windows.Forms.Label();
            this.tbNombreEmpledo = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCveEmpleados
            // 
            this.cbCveEmpleados.FormattingEnabled = true;
            this.cbCveEmpleados.Location = new System.Drawing.Point(143, 12);
            this.cbCveEmpleados.Name = "cbCveEmpleados";
            this.cbCveEmpleados.Size = new System.Drawing.Size(247, 21);
            this.cbCveEmpleados.TabIndex = 0;
            this.cbCveEmpleados.SelectedIndexChanged += new System.EventHandler(this.cbCveEmpleados_SelectedIndexChanged);
            // 
            // labelCveEmpleado
            // 
            this.labelCveEmpleado.AutoSize = true;
            this.labelCveEmpleado.Location = new System.Drawing.Point(12, 20);
            this.labelCveEmpleado.Name = "labelCveEmpleado";
            this.labelCveEmpleado.Size = new System.Drawing.Size(98, 13);
            this.labelCveEmpleado.TabIndex = 1;
            this.labelCveEmpleado.Text = "Clave de empleado";
            // 
            // labelNombreEmpleado
            // 
            this.labelNombreEmpleado.AutoSize = true;
            this.labelNombreEmpleado.Location = new System.Drawing.Point(66, 56);
            this.labelNombreEmpleado.Name = "labelNombreEmpleado";
            this.labelNombreEmpleado.Size = new System.Drawing.Size(44, 13);
            this.labelNombreEmpleado.TabIndex = 2;
            this.labelNombreEmpleado.Text = "Nombre";
            // 
            // tbNombreEmpledo
            // 
            this.tbNombreEmpledo.Location = new System.Drawing.Point(143, 49);
            this.tbNombreEmpledo.Name = "tbNombreEmpledo";
            this.tbNombreEmpledo.ReadOnly = true;
            this.tbNombreEmpledo.Size = new System.Drawing.Size(247, 20);
            this.tbNombreEmpledo.TabIndex = 3;
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Location = new System.Drawing.Point(49, 92);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(61, 13);
            this.labelContraseña.TabIndex = 4;
            this.labelContraseña.Text = "Contraseña";
            // 
            // tbContraseña
            // 
            this.tbContraseña.Location = new System.Drawing.Point(143, 85);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Size = new System.Drawing.Size(247, 20);
            this.tbContraseña.TabIndex = 5;
            this.tbContraseña.Text = "AdministracionBasesDatos";
            this.tbContraseña.UseSystemPasswordChar = true;
            // 
            // btnAcceder
            // 
            this.btnAcceder.Location = new System.Drawing.Point(143, 121);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(75, 38);
            this.btnAcceder.TabIndex = 6;
            this.btnAcceder.Text = "Acceder";
            this.btnAcceder.UseVisualStyleBackColor = true;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(224, 121);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Cancelar";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 171);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.tbNombreEmpledo);
            this.Controls.Add(this.labelNombreEmpleado);
            this.Controls.Add(this.labelCveEmpleado);
            this.Controls.Add(this.cbCveEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesión";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCveEmpleados;
        private System.Windows.Forms.Label labelCveEmpleado;
        private System.Windows.Forms.Label labelNombreEmpleado;
        private System.Windows.Forms.TextBox tbNombreEmpledo;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.Button btnExit;
    }
}