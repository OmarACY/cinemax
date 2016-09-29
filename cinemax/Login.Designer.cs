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
            this.cbCveEmpleados = new System.Windows.Forms.ComboBox();
            this.labelCveEmpleado = new System.Windows.Forms.Label();
            this.labelNombreEmpleado = new System.Windows.Forms.Label();
            this.tbNombreEmpledo = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.btSalir = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbCinemax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCveEmpleados
            // 
            this.cbCveEmpleados.BackColor = System.Drawing.SystemColors.MenuText;
            this.cbCveEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCveEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCveEmpleados.ForeColor = System.Drawing.Color.LightGray;
            this.cbCveEmpleados.FormattingEnabled = true;
            this.cbCveEmpleados.Location = new System.Drawing.Point(187, 69);
            this.cbCveEmpleados.Name = "cbCveEmpleados";
            this.cbCveEmpleados.Size = new System.Drawing.Size(247, 26);
            this.cbCveEmpleados.TabIndex = 0;
            this.cbCveEmpleados.SelectedIndexChanged += new System.EventHandler(this.cbCveEmpleados_SelectedIndexChanged);
            // 
            // labelCveEmpleado
            // 
            this.labelCveEmpleado.AutoSize = true;
            this.labelCveEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.labelCveEmpleado.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCveEmpleado.ForeColor = System.Drawing.Color.LightGray;
            this.labelCveEmpleado.Location = new System.Drawing.Point(25, 69);
            this.labelCveEmpleado.Name = "labelCveEmpleado";
            this.labelCveEmpleado.Size = new System.Drawing.Size(161, 28);
            this.labelCveEmpleado.TabIndex = 1;
            this.labelCveEmpleado.Text = "Clave de empleado";
            // 
            // labelNombreEmpleado
            // 
            this.labelNombreEmpleado.AutoSize = true;
            this.labelNombreEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.labelNombreEmpleado.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreEmpleado.ForeColor = System.Drawing.Color.LightGray;
            this.labelNombreEmpleado.Location = new System.Drawing.Point(111, 104);
            this.labelNombreEmpleado.Name = "labelNombreEmpleado";
            this.labelNombreEmpleado.Size = new System.Drawing.Size(75, 28);
            this.labelNombreEmpleado.TabIndex = 2;
            this.labelNombreEmpleado.Text = "Nombre";
            // 
            // tbNombreEmpledo
            // 
            this.tbNombreEmpledo.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbNombreEmpledo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombreEmpledo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreEmpledo.ForeColor = System.Drawing.Color.LightGray;
            this.tbNombreEmpledo.Location = new System.Drawing.Point(187, 106);
            this.tbNombreEmpledo.Name = "tbNombreEmpledo";
            this.tbNombreEmpledo.ReadOnly = true;
            this.tbNombreEmpledo.Size = new System.Drawing.Size(247, 24);
            this.tbNombreEmpledo.TabIndex = 3;
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.BackColor = System.Drawing.Color.Transparent;
            this.labelContraseña.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseña.ForeColor = System.Drawing.Color.LightGray;
            this.labelContraseña.Location = new System.Drawing.Point(83, 140);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(103, 28);
            this.labelContraseña.TabIndex = 4;
            this.labelContraseña.Text = "Contraseña";
            // 
            // tbContraseña
            // 
            this.tbContraseña.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContraseña.ForeColor = System.Drawing.Color.LightGray;
            this.tbContraseña.Location = new System.Drawing.Point(187, 142);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Size = new System.Drawing.Size(247, 24);
            this.tbContraseña.TabIndex = 5;
            this.tbContraseña.Text = "AdministracionBasesDatos";
            this.tbContraseña.UseSystemPasswordChar = true;
            // 
            // btSalir
            // 
            this.btSalir.BackColor = System.Drawing.Color.Transparent;
            this.btSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalir.Image = global::cinemax.Properties.Resources.salir;
            this.btSalir.Location = new System.Drawing.Point(396, 178);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(38, 38);
            this.btSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btSalir.TabIndex = 8;
            this.btSalir.TabStop = false;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::cinemax.Properties.Resources.entrar;
            this.pictureBox1.Location = new System.Drawing.Point(288, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbCinemax
            // 
            this.lbCinemax.AutoSize = true;
            this.lbCinemax.BackColor = System.Drawing.Color.Transparent;
            this.lbCinemax.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCinemax.ForeColor = System.Drawing.Color.LightGray;
            this.lbCinemax.Location = new System.Drawing.Point(210, 8);
            this.lbCinemax.Name = "lbCinemax";
            this.lbCinemax.Size = new System.Drawing.Size(122, 42);
            this.lbCinemax.TabIndex = 10;
            this.lbCinemax.Text = "Cinemax";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(218, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Entrar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(344, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "Salir";
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogo.Image = global::cinemax.Properties.Resources.logo_claro;
            this.pbLogo.Location = new System.Drawing.Point(169, 8);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(35, 35);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 13;
            this.pbLogo.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::cinemax.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(481, 228);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCinemax);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.tbNombreEmpledo);
            this.Controls.Add(this.labelNombreEmpleado);
            this.Controls.Add(this.labelCveEmpleado);
            this.Controls.Add(this.cbCveEmpleados);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesión";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
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
        private System.Windows.Forms.PictureBox btSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCinemax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}