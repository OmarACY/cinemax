﻿namespace cinemax
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcPrincipal = new System.Windows.Forms.TabControl();
            this.tpVenta = new System.Windows.Forms.TabPage();
            this.tpEmpleado = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbEmpleado = new System.Windows.Forms.GroupBox();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.btActualizaEmpeado = new System.Windows.Forms.Button();
            this.btEliminaEmpeado = new System.Windows.Forms.Button();
            this.btInsertaEmpeado = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbNumeroEmp = new System.Windows.Forms.Label();
            this.tbNumeroEmp = new System.Windows.Forms.TextBox();
            this.lbCalleEmp = new System.Windows.Forms.Label();
            this.tbCalleEmp = new System.Windows.Forms.TextBox();
            this.lbColoniaEmp = new System.Windows.Forms.Label();
            this.tbColoniaEmp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dpFechaEmp = new System.Windows.Forms.DateTimePicker();
            this.lbFechaEmp = new System.Windows.Forms.Label();
            this.lbApmEmp = new System.Windows.Forms.Label();
            this.lbAppEmp = new System.Windows.Forms.Label();
            this.tbApmEmp = new System.Windows.Forms.TextBox();
            this.tbAppEmp = new System.Windows.Forms.TextBox();
            this.lbNombreEmp = new System.Windows.Forms.Label();
            this.tbNombreEmp = new System.Windows.Forms.TextBox();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.tcPrincipal.SuspendLayout();
            this.tpEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbEmpleado.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPrincipal
            // 
            this.tcPrincipal.Controls.Add(this.tpVenta);
            this.tcPrincipal.Controls.Add(this.tpEmpleado);
            this.tcPrincipal.Cursor = System.Windows.Forms.Cursors.Default;
            this.tcPrincipal.HotTrack = true;
            this.tcPrincipal.Location = new System.Drawing.Point(12, 25);
            this.tcPrincipal.Multiline = true;
            this.tcPrincipal.Name = "tcPrincipal";
            this.tcPrincipal.SelectedIndex = 0;
            this.tcPrincipal.Size = new System.Drawing.Size(976, 563);
            this.tcPrincipal.TabIndex = 1;
            // 
            // tpVenta
            // 
            this.tpVenta.BackColor = System.Drawing.Color.Black;
            this.tpVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpVenta.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpVenta.Location = new System.Drawing.Point(4, 22);
            this.tpVenta.Name = "tpVenta";
            this.tpVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tpVenta.Size = new System.Drawing.Size(968, 537);
            this.tpVenta.TabIndex = 0;
            this.tpVenta.Text = "Venta";
            // 
            // tpEmpleado
            // 
            this.tpEmpleado.BackColor = System.Drawing.Color.Black;
            this.tpEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpEmpleado.Controls.Add(this.dataGridView1);
            this.tpEmpleado.Controls.Add(this.gbEmpleado);
            this.tpEmpleado.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpEmpleado.Location = new System.Drawing.Point(4, 22);
            this.tpEmpleado.Name = "tpEmpleado";
            this.tpEmpleado.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmpleado.Size = new System.Drawing.Size(968, 537);
            this.tpEmpleado.TabIndex = 1;
            this.tpEmpleado.Text = "Empleado";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(956, 304);
            this.dataGridView1.TabIndex = 1;
            // 
            // gbEmpleado
            // 
            this.gbEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.gbEmpleado.Controls.Add(this.lbMensaje);
            this.gbEmpleado.Controls.Add(this.btActualizaEmpeado);
            this.gbEmpleado.Controls.Add(this.btEliminaEmpeado);
            this.gbEmpleado.Controls.Add(this.btInsertaEmpeado);
            this.gbEmpleado.Controls.Add(this.groupBox2);
            this.gbEmpleado.Controls.Add(this.groupBox1);
            this.gbEmpleado.ForeColor = System.Drawing.Color.LightGray;
            this.gbEmpleado.Location = new System.Drawing.Point(6, 6);
            this.gbEmpleado.Name = "gbEmpleado";
            this.gbEmpleado.Size = new System.Drawing.Size(956, 186);
            this.gbEmpleado.TabIndex = 0;
            this.gbEmpleado.TabStop = false;
            this.gbEmpleado.Text = "Informacion";
            // 
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lbMensaje.ForeColor = System.Drawing.Color.Red;
            this.lbMensaje.Location = new System.Drawing.Point(583, 164);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(106, 13);
            this.lbMensaje.TabIndex = 9;
            this.lbMensaje.Text = "* Campos requieridos";
            // 
            // btActualizaEmpeado
            // 
            this.btActualizaEmpeado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btActualizaEmpeado.Location = new System.Drawing.Point(695, 159);
            this.btActualizaEmpeado.Name = "btActualizaEmpeado";
            this.btActualizaEmpeado.Size = new System.Drawing.Size(75, 23);
            this.btActualizaEmpeado.TabIndex = 4;
            this.btActualizaEmpeado.Text = "Actualizar";
            this.btActualizaEmpeado.UseVisualStyleBackColor = true;
            // 
            // btEliminaEmpeado
            // 
            this.btEliminaEmpeado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btEliminaEmpeado.Location = new System.Drawing.Point(776, 159);
            this.btEliminaEmpeado.Name = "btEliminaEmpeado";
            this.btEliminaEmpeado.Size = new System.Drawing.Size(75, 23);
            this.btEliminaEmpeado.TabIndex = 3;
            this.btEliminaEmpeado.Text = "Eliminar";
            this.btEliminaEmpeado.UseVisualStyleBackColor = true;
            // 
            // btInsertaEmpeado
            // 
            this.btInsertaEmpeado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btInsertaEmpeado.Location = new System.Drawing.Point(857, 159);
            this.btInsertaEmpeado.Name = "btInsertaEmpeado";
            this.btInsertaEmpeado.Size = new System.Drawing.Size(75, 23);
            this.btInsertaEmpeado.TabIndex = 2;
            this.btInsertaEmpeado.Text = "Agregar";
            this.btInsertaEmpeado.UseVisualStyleBackColor = true;
            this.btInsertaEmpeado.Click += new System.EventHandler(this.btInsertaEmpeado_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbNumeroEmp);
            this.groupBox2.Controls.Add(this.tbNumeroEmp);
            this.groupBox2.Controls.Add(this.lbCalleEmp);
            this.groupBox2.Controls.Add(this.tbCalleEmp);
            this.groupBox2.Controls.Add(this.lbColoniaEmp);
            this.groupBox2.Controls.Add(this.tbColoniaEmp);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(423, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de contacto";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(367, 49);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(154, 20);
            this.textBox6.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Celular";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(367, 23);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(154, 20);
            this.textBox5.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Telefono";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNumeroEmp
            // 
            this.lbNumeroEmp.AutoSize = true;
            this.lbNumeroEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNumeroEmp.Location = new System.Drawing.Point(16, 78);
            this.lbNumeroEmp.Name = "lbNumeroEmp";
            this.lbNumeroEmp.Size = new System.Drawing.Size(44, 13);
            this.lbNumeroEmp.TabIndex = 11;
            this.lbNumeroEmp.Text = "Numero";
            this.lbNumeroEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbNumeroEmp
            // 
            this.tbNumeroEmp.Location = new System.Drawing.Point(68, 75);
            this.tbNumeroEmp.Name = "tbNumeroEmp";
            this.tbNumeroEmp.Size = new System.Drawing.Size(238, 20);
            this.tbNumeroEmp.TabIndex = 12;
            // 
            // lbCalleEmp
            // 
            this.lbCalleEmp.AutoSize = true;
            this.lbCalleEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCalleEmp.Location = new System.Drawing.Point(30, 52);
            this.lbCalleEmp.Name = "lbCalleEmp";
            this.lbCalleEmp.Size = new System.Drawing.Size(30, 13);
            this.lbCalleEmp.TabIndex = 9;
            this.lbCalleEmp.Text = "Calle";
            this.lbCalleEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCalleEmp
            // 
            this.tbCalleEmp.Location = new System.Drawing.Point(68, 49);
            this.tbCalleEmp.Name = "tbCalleEmp";
            this.tbCalleEmp.Size = new System.Drawing.Size(238, 20);
            this.tbCalleEmp.TabIndex = 10;
            // 
            // lbColoniaEmp
            // 
            this.lbColoniaEmp.AutoSize = true;
            this.lbColoniaEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbColoniaEmp.Location = new System.Drawing.Point(18, 26);
            this.lbColoniaEmp.Name = "lbColoniaEmp";
            this.lbColoniaEmp.Size = new System.Drawing.Size(42, 13);
            this.lbColoniaEmp.TabIndex = 8;
            this.lbColoniaEmp.Text = "Colonia";
            this.lbColoniaEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbColoniaEmp
            // 
            this.tbColoniaEmp.Location = new System.Drawing.Point(68, 23);
            this.tbColoniaEmp.Name = "tbColoniaEmp";
            this.tbColoniaEmp.Size = new System.Drawing.Size(238, 20);
            this.tbColoniaEmp.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dpFechaEmp);
            this.groupBox1.Controls.Add(this.lbFechaEmp);
            this.groupBox1.Controls.Add(this.lbApmEmp);
            this.groupBox1.Controls.Add(this.lbAppEmp);
            this.groupBox1.Controls.Add(this.tbApmEmp);
            this.groupBox1.Controls.Add(this.tbAppEmp);
            this.groupBox1.Controls.Add(this.lbNombreEmp);
            this.groupBox1.Controls.Add(this.tbNombreEmp);
            this.groupBox1.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // dpFechaEmp
            // 
            this.dpFechaEmp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaEmp.Location = new System.Drawing.Point(127, 101);
            this.dpFechaEmp.MaxDate = new System.DateTime(1998, 12, 31, 0, 0, 0, 0);
            this.dpFechaEmp.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dpFechaEmp.Name = "dpFechaEmp";
            this.dpFechaEmp.Size = new System.Drawing.Size(274, 20);
            this.dpFechaEmp.TabIndex = 8;
            this.dpFechaEmp.Value = new System.DateTime(1998, 12, 31, 0, 0, 0, 0);
            // 
            // lbFechaEmp
            // 
            this.lbFechaEmp.AutoSize = true;
            this.lbFechaEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbFechaEmp.Location = new System.Drawing.Point(15, 104);
            this.lbFechaEmp.Name = "lbFechaEmp";
            this.lbFechaEmp.Size = new System.Drawing.Size(106, 13);
            this.lbFechaEmp.TabIndex = 7;
            this.lbFechaEmp.Text = "Fecha de nacimiento";
            this.lbFechaEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbApmEmp
            // 
            this.lbApmEmp.AutoSize = true;
            this.lbApmEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbApmEmp.Location = new System.Drawing.Point(34, 78);
            this.lbApmEmp.Name = "lbApmEmp";
            this.lbApmEmp.Size = new System.Drawing.Size(85, 13);
            this.lbApmEmp.TabIndex = 5;
            this.lbApmEmp.Text = "Apellido materno";
            this.lbApmEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbAppEmp
            // 
            this.lbAppEmp.AutoSize = true;
            this.lbAppEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbAppEmp.Location = new System.Drawing.Point(36, 52);
            this.lbAppEmp.Name = "lbAppEmp";
            this.lbAppEmp.Size = new System.Drawing.Size(83, 13);
            this.lbAppEmp.TabIndex = 4;
            this.lbAppEmp.Text = "Apellido paterno";
            this.lbAppEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbApmEmp
            // 
            this.tbApmEmp.Location = new System.Drawing.Point(127, 75);
            this.tbApmEmp.Name = "tbApmEmp";
            this.tbApmEmp.Size = new System.Drawing.Size(274, 20);
            this.tbApmEmp.TabIndex = 3;
            // 
            // tbAppEmp
            // 
            this.tbAppEmp.Location = new System.Drawing.Point(127, 49);
            this.tbAppEmp.Name = "tbAppEmp";
            this.tbAppEmp.Size = new System.Drawing.Size(274, 20);
            this.tbAppEmp.TabIndex = 2;
            // 
            // lbNombreEmp
            // 
            this.lbNombreEmp.AutoSize = true;
            this.lbNombreEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNombreEmp.Location = new System.Drawing.Point(61, 26);
            this.lbNombreEmp.Name = "lbNombreEmp";
            this.lbNombreEmp.Size = new System.Drawing.Size(58, 13);
            this.lbNombreEmp.TabIndex = 1;
            this.lbNombreEmp.Text = "Nombre (s)";
            this.lbNombreEmp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNombreEmp
            // 
            this.tbNombreEmp.BackColor = System.Drawing.SystemColors.Window;
            this.tbNombreEmp.Location = new System.Drawing.Point(127, 23);
            this.tbNombreEmp.Name = "tbNombreEmp";
            this.tbNombreEmp.Size = new System.Drawing.Size(274, 20);
            this.tbNombreEmp.TabIndex = 0;
            // 
            // pbCerrar
            // 
            this.pbCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCerrar.Image = global::cinemax.Properties.Resources.cerrar2;
            this.pbCerrar.Location = new System.Drawing.Point(976, 4);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(20, 20);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCerrar.TabIndex = 2;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pbCerrar);
            this.Controls.Add(this.tcPrincipal);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cinemax";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.tcPrincipal.ResumeLayout(false);
            this.tpEmpleado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbEmpleado.ResumeLayout(false);
            this.gbEmpleado.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPrincipal;
        private System.Windows.Forms.TabPage tpVenta;
        private System.Windows.Forms.TabPage tpEmpleado;
        private System.Windows.Forms.GroupBox gbEmpleado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbApmEmp;
        private System.Windows.Forms.Label lbAppEmp;
        private System.Windows.Forms.TextBox tbApmEmp;
        private System.Windows.Forms.TextBox tbAppEmp;
        private System.Windows.Forms.Label lbNombreEmp;
        private System.Windows.Forms.TextBox tbNombreEmp;
        private System.Windows.Forms.Label lbFechaEmp;
        private System.Windows.Forms.TextBox tbColoniaEmp;
        private System.Windows.Forms.Label lbNumeroEmp;
        private System.Windows.Forms.TextBox tbNumeroEmp;
        private System.Windows.Forms.Label lbCalleEmp;
        private System.Windows.Forms.TextBox tbCalleEmp;
        private System.Windows.Forms.Label lbColoniaEmp;
        private System.Windows.Forms.Label lbMensaje;
        private System.Windows.Forms.Button btActualizaEmpeado;
        private System.Windows.Forms.Button btEliminaEmpeado;
        private System.Windows.Forms.Button btInsertaEmpeado;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpFechaEmp;
        private System.Windows.Forms.PictureBox pbCerrar;
    }
}

