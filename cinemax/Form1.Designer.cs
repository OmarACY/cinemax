namespace cinemax
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
            this.dgEmpleados = new System.Windows.Forms.DataGridView();
            this.gbEmpleado = new System.Windows.Forms.GroupBox();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.btActualizaEmpleado = new System.Windows.Forms.Button();
            this.btEliminaEmpleado = new System.Windows.Forms.Button();
            this.btInsertaEmpleado = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCelEmp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTelEmp = new System.Windows.Forms.TextBox();
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
            this.lbCinemax = new System.Windows.Forms.Label();
            this.tpMembresia = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbMensajeMem = new System.Windows.Forms.Label();
            this.btActualizaMem = new System.Windows.Forms.Button();
            this.btEliminaMem = new System.Windows.Forms.Button();
            this.btInsertaMem = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbNumeroMem = new System.Windows.Forms.Label();
            this.tbNumeroMem = new System.Windows.Forms.TextBox();
            this.lbCalleMem = new System.Windows.Forms.Label();
            this.tbCalleMem = new System.Windows.Forms.TextBox();
            this.lbColoniaMem = new System.Windows.Forms.Label();
            this.tbColoniaMem = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dpFechaMem = new System.Windows.Forms.DateTimePicker();
            this.lbFechaMem = new System.Windows.Forms.Label();
            this.lbApmMem = new System.Windows.Forms.Label();
            this.lbAppMem = new System.Windows.Forms.Label();
            this.tbApmMem = new System.Windows.Forms.TextBox();
            this.tbAppMem = new System.Windows.Forms.TextBox();
            this.lbNombreMem = new System.Windows.Forms.Label();
            this.tbNombreMem = new System.Windows.Forms.TextBox();
            this.dgMembresias = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbPuntosMem = new System.Windows.Forms.Label();
            this.lbTipoMem = new System.Windows.Forms.Label();
            this.cbTipoMem = new System.Windows.Forms.ComboBox();
            this.nuPuntosMem = new System.Windows.Forms.NumericUpDown();
            this.tcPrincipal.SuspendLayout();
            this.tpEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpleados)).BeginInit();
            this.gbEmpleado.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            this.tpMembresia.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMembresias)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPuntosMem)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPrincipal
            // 
            this.tcPrincipal.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcPrincipal.Controls.Add(this.tpVenta);
            this.tcPrincipal.Controls.Add(this.tpEmpleado);
            this.tcPrincipal.Controls.Add(this.tpMembresia);
            this.tcPrincipal.Cursor = System.Windows.Forms.Cursors.Default;
            this.tcPrincipal.Location = new System.Drawing.Point(4, 27);
            this.tcPrincipal.Multiline = true;
            this.tcPrincipal.Name = "tcPrincipal";
            this.tcPrincipal.SelectedIndex = 0;
            this.tcPrincipal.Size = new System.Drawing.Size(992, 570);
            this.tcPrincipal.TabIndex = 1;
            this.tcPrincipal.Tag = "Mensaje";
            this.tcPrincipal.SelectedIndexChanged += new System.EventHandler(this.tcPrincipal_SelectedIndexChanged);
            // 
            // tpVenta
            // 
            this.tpVenta.BackColor = System.Drawing.Color.Black;
            this.tpVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpVenta.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpVenta.Location = new System.Drawing.Point(4, 25);
            this.tpVenta.Name = "tpVenta";
            this.tpVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tpVenta.Size = new System.Drawing.Size(984, 541);
            this.tpVenta.TabIndex = 0;
            this.tpVenta.Text = "Venta";
            // 
            // tpEmpleado
            // 
            this.tpEmpleado.BackColor = System.Drawing.Color.Black;
            this.tpEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpEmpleado.Controls.Add(this.dgEmpleados);
            this.tpEmpleado.Controls.Add(this.gbEmpleado);
            this.tpEmpleado.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpEmpleado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpEmpleado.Location = new System.Drawing.Point(4, 25);
            this.tpEmpleado.Name = "tpEmpleado";
            this.tpEmpleado.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmpleado.Size = new System.Drawing.Size(984, 541);
            this.tpEmpleado.TabIndex = 1;
            this.tpEmpleado.Text = "Empleado";
            // 
            // dgEmpleados
            // 
            this.dgEmpleados.AllowUserToAddRows = false;
            this.dgEmpleados.AllowUserToDeleteRows = false;
            this.dgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmpleados.Location = new System.Drawing.Point(6, 198);
            this.dgEmpleados.Name = "dgEmpleados";
            this.dgEmpleados.ReadOnly = true;
            this.dgEmpleados.Size = new System.Drawing.Size(972, 337);
            this.dgEmpleados.TabIndex = 1;
            this.dgEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmpleados_CellContentClick);
            this.dgEmpleados.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgEmpleados_RowHeaderMouseClick);
            // 
            // gbEmpleado
            // 
            this.gbEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.gbEmpleado.Controls.Add(this.lbMensaje);
            this.gbEmpleado.Controls.Add(this.btActualizaEmpleado);
            this.gbEmpleado.Controls.Add(this.btEliminaEmpleado);
            this.gbEmpleado.Controls.Add(this.btInsertaEmpleado);
            this.gbEmpleado.Controls.Add(this.groupBox2);
            this.gbEmpleado.Controls.Add(this.groupBox1);
            this.gbEmpleado.ForeColor = System.Drawing.Color.LightGray;
            this.gbEmpleado.Location = new System.Drawing.Point(6, 6);
            this.gbEmpleado.Name = "gbEmpleado";
            this.gbEmpleado.Size = new System.Drawing.Size(972, 186);
            this.gbEmpleado.TabIndex = 0;
            this.gbEmpleado.TabStop = false;
            this.gbEmpleado.Text = "Informacion";
            // 
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lbMensaje.ForeColor = System.Drawing.Color.Red;
            this.lbMensaje.Location = new System.Drawing.Point(617, 164);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(106, 13);
            this.lbMensaje.TabIndex = 9;
            this.lbMensaje.Text = "* Campos requieridos";
            this.lbMensaje.Visible = false;
            // 
            // btActualizaEmpleado
            // 
            this.btActualizaEmpleado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btActualizaEmpleado.Location = new System.Drawing.Point(729, 159);
            this.btActualizaEmpleado.Name = "btActualizaEmpleado";
            this.btActualizaEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btActualizaEmpleado.TabIndex = 2;
            this.btActualizaEmpleado.Text = "Actualizar";
            this.btActualizaEmpleado.UseVisualStyleBackColor = true;
            this.btActualizaEmpleado.Click += new System.EventHandler(this.btActualizaEmpleado_Click);
            // 
            // btEliminaEmpleado
            // 
            this.btEliminaEmpleado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btEliminaEmpleado.Location = new System.Drawing.Point(810, 159);
            this.btEliminaEmpleado.Name = "btEliminaEmpleado";
            this.btEliminaEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btEliminaEmpleado.TabIndex = 1;
            this.btEliminaEmpleado.Text = "Eliminar";
            this.btEliminaEmpleado.UseVisualStyleBackColor = true;
            this.btEliminaEmpleado.Click += new System.EventHandler(this.btEliminaEmpleado_Click);
            // 
            // btInsertaEmpleado
            // 
            this.btInsertaEmpleado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btInsertaEmpleado.Location = new System.Drawing.Point(891, 159);
            this.btInsertaEmpleado.Name = "btInsertaEmpleado";
            this.btInsertaEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btInsertaEmpleado.TabIndex = 0;
            this.btInsertaEmpleado.Text = "Agregar";
            this.btInsertaEmpleado.UseVisualStyleBackColor = true;
            this.btInsertaEmpleado.Click += new System.EventHandler(this.btInsertaEmpeado_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCelEmp);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbTelEmp);
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
            this.groupBox2.Size = new System.Drawing.Size(543, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de contacto";
            // 
            // tbCelEmp
            // 
            this.tbCelEmp.Location = new System.Drawing.Point(377, 49);
            this.tbCelEmp.Name = "tbCelEmp";
            this.tbCelEmp.Size = new System.Drawing.Size(160, 20);
            this.tbCelEmp.TabIndex = 8;
            this.tbCelEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCelEmp_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Celular";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbTelEmp
            // 
            this.tbTelEmp.Location = new System.Drawing.Point(377, 23);
            this.tbTelEmp.Name = "tbTelEmp";
            this.tbTelEmp.Size = new System.Drawing.Size(160, 20);
            this.tbTelEmp.TabIndex = 7;
            this.tbTelEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTelEmp_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 26);
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
            this.tbNumeroEmp.Size = new System.Drawing.Size(248, 20);
            this.tbNumeroEmp.TabIndex = 6;
            this.tbNumeroEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeroEmp_KeyPress);
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
            this.tbCalleEmp.MaxLength = 45;
            this.tbCalleEmp.Name = "tbCalleEmp";
            this.tbCalleEmp.Size = new System.Drawing.Size(248, 20);
            this.tbCalleEmp.TabIndex = 5;
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
            this.tbColoniaEmp.MaxLength = 45;
            this.tbColoniaEmp.Name = "tbColoniaEmp";
            this.tbColoniaEmp.Size = new System.Drawing.Size(248, 20);
            this.tbColoniaEmp.TabIndex = 4;
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
            this.dpFechaEmp.TabIndex = 3;
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
            this.tbApmEmp.MaxLength = 30;
            this.tbApmEmp.Name = "tbApmEmp";
            this.tbApmEmp.Size = new System.Drawing.Size(274, 20);
            this.tbApmEmp.TabIndex = 2;
            // 
            // tbAppEmp
            // 
            this.tbAppEmp.Location = new System.Drawing.Point(127, 49);
            this.tbAppEmp.MaxLength = 30;
            this.tbAppEmp.Name = "tbAppEmp";
            this.tbAppEmp.Size = new System.Drawing.Size(274, 20);
            this.tbAppEmp.TabIndex = 1;
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
            this.tbNombreEmp.MaxLength = 30;
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
            // lbCinemax
            // 
            this.lbCinemax.AutoSize = true;
            this.lbCinemax.BackColor = System.Drawing.Color.Transparent;
            this.lbCinemax.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCinemax.Location = new System.Drawing.Point(490, 7);
            this.lbCinemax.Name = "lbCinemax";
            this.lbCinemax.Size = new System.Drawing.Size(68, 17);
            this.lbCinemax.TabIndex = 3;
            this.lbCinemax.Text = "Cinemax";
            // 
            // tpMembresia
            // 
            this.tpMembresia.BackColor = System.Drawing.Color.Black;
            this.tpMembresia.Controls.Add(this.dgMembresias);
            this.tpMembresia.Controls.Add(this.groupBox3);
            this.tpMembresia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpMembresia.Location = new System.Drawing.Point(4, 25);
            this.tpMembresia.Name = "tpMembresia";
            this.tpMembresia.Padding = new System.Windows.Forms.Padding(3);
            this.tpMembresia.Size = new System.Drawing.Size(984, 541);
            this.tpMembresia.TabIndex = 2;
            this.tpMembresia.Text = "Membresía";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.lbMensajeMem);
            this.groupBox3.Controls.Add(this.btActualizaMem);
            this.groupBox3.Controls.Add(this.btEliminaMem);
            this.groupBox3.Controls.Add(this.btInsertaMem);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(972, 186);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacion";
            // 
            // lbMensajeMem
            // 
            this.lbMensajeMem.AutoSize = true;
            this.lbMensajeMem.BackColor = System.Drawing.Color.Transparent;
            this.lbMensajeMem.ForeColor = System.Drawing.Color.Red;
            this.lbMensajeMem.Location = new System.Drawing.Point(617, 164);
            this.lbMensajeMem.Name = "lbMensajeMem";
            this.lbMensajeMem.Size = new System.Drawing.Size(106, 13);
            this.lbMensajeMem.TabIndex = 9;
            this.lbMensajeMem.Tag = "Mensaje";
            this.lbMensajeMem.Text = "* Campos requieridos";
            this.lbMensajeMem.Visible = false;
            // 
            // btActualizaMem
            // 
            this.btActualizaMem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btActualizaMem.Location = new System.Drawing.Point(729, 159);
            this.btActualizaMem.Name = "btActualizaMem";
            this.btActualizaMem.Size = new System.Drawing.Size(75, 23);
            this.btActualizaMem.TabIndex = 2;
            this.btActualizaMem.Text = "Actualizar";
            this.btActualizaMem.UseVisualStyleBackColor = true;
            // 
            // btEliminaMem
            // 
            this.btEliminaMem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btEliminaMem.Location = new System.Drawing.Point(810, 159);
            this.btEliminaMem.Name = "btEliminaMem";
            this.btEliminaMem.Size = new System.Drawing.Size(75, 23);
            this.btEliminaMem.TabIndex = 1;
            this.btEliminaMem.Text = "Eliminar";
            this.btEliminaMem.UseVisualStyleBackColor = true;
            // 
            // btInsertaMem
            // 
            this.btInsertaMem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btInsertaMem.Location = new System.Drawing.Point(891, 159);
            this.btInsertaMem.Name = "btInsertaMem";
            this.btInsertaMem.Size = new System.Drawing.Size(75, 23);
            this.btInsertaMem.TabIndex = 0;
            this.btInsertaMem.Text = "Agregar";
            this.btInsertaMem.UseVisualStyleBackColor = true;
            this.btInsertaMem.Click += new System.EventHandler(this.btInsertaMem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbNumeroMem);
            this.groupBox4.Controls.Add(this.tbNumeroMem);
            this.groupBox4.Controls.Add(this.lbCalleMem);
            this.groupBox4.Controls.Add(this.tbCalleMem);
            this.groupBox4.Controls.Add(this.lbColoniaMem);
            this.groupBox4.Controls.Add(this.tbColoniaMem);
            this.groupBox4.ForeColor = System.Drawing.Color.Silver;
            this.groupBox4.Location = new System.Drawing.Point(423, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 138);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos de contacto";
            // 
            // lbNumeroMem
            // 
            this.lbNumeroMem.AutoSize = true;
            this.lbNumeroMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNumeroMem.Location = new System.Drawing.Point(16, 78);
            this.lbNumeroMem.Name = "lbNumeroMem";
            this.lbNumeroMem.Size = new System.Drawing.Size(44, 13);
            this.lbNumeroMem.TabIndex = 11;
            this.lbNumeroMem.Text = "Numero";
            this.lbNumeroMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbNumeroMem
            // 
            this.tbNumeroMem.Location = new System.Drawing.Point(68, 75);
            this.tbNumeroMem.Name = "tbNumeroMem";
            this.tbNumeroMem.Size = new System.Drawing.Size(248, 20);
            this.tbNumeroMem.TabIndex = 6;
            // 
            // lbCalleMem
            // 
            this.lbCalleMem.AutoSize = true;
            this.lbCalleMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCalleMem.Location = new System.Drawing.Point(30, 52);
            this.lbCalleMem.Name = "lbCalleMem";
            this.lbCalleMem.Size = new System.Drawing.Size(30, 13);
            this.lbCalleMem.TabIndex = 9;
            this.lbCalleMem.Text = "Calle";
            this.lbCalleMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCalleMem
            // 
            this.tbCalleMem.Location = new System.Drawing.Point(68, 49);
            this.tbCalleMem.MaxLength = 45;
            this.tbCalleMem.Name = "tbCalleMem";
            this.tbCalleMem.Size = new System.Drawing.Size(248, 20);
            this.tbCalleMem.TabIndex = 5;
            // 
            // lbColoniaMem
            // 
            this.lbColoniaMem.AutoSize = true;
            this.lbColoniaMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbColoniaMem.Location = new System.Drawing.Point(18, 26);
            this.lbColoniaMem.Name = "lbColoniaMem";
            this.lbColoniaMem.Size = new System.Drawing.Size(42, 13);
            this.lbColoniaMem.TabIndex = 8;
            this.lbColoniaMem.Text = "Colonia";
            this.lbColoniaMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbColoniaMem
            // 
            this.tbColoniaMem.Location = new System.Drawing.Point(68, 23);
            this.tbColoniaMem.MaxLength = 45;
            this.tbColoniaMem.Name = "tbColoniaMem";
            this.tbColoniaMem.Size = new System.Drawing.Size(248, 20);
            this.tbColoniaMem.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dpFechaMem);
            this.groupBox5.Controls.Add(this.lbFechaMem);
            this.groupBox5.Controls.Add(this.lbApmMem);
            this.groupBox5.Controls.Add(this.lbAppMem);
            this.groupBox5.Controls.Add(this.tbApmMem);
            this.groupBox5.Controls.Add(this.tbAppMem);
            this.groupBox5.Controls.Add(this.lbNombreMem);
            this.groupBox5.Controls.Add(this.tbNombreMem);
            this.groupBox5.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(411, 138);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos personales";
            // 
            // dpFechaMem
            // 
            this.dpFechaMem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaMem.Location = new System.Drawing.Point(127, 101);
            this.dpFechaMem.MaxDate = new System.DateTime(1998, 12, 31, 0, 0, 0, 0);
            this.dpFechaMem.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dpFechaMem.Name = "dpFechaMem";
            this.dpFechaMem.Size = new System.Drawing.Size(274, 20);
            this.dpFechaMem.TabIndex = 3;
            this.dpFechaMem.Value = new System.DateTime(1998, 12, 31, 0, 0, 0, 0);
            // 
            // lbFechaMem
            // 
            this.lbFechaMem.AutoSize = true;
            this.lbFechaMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbFechaMem.Location = new System.Drawing.Point(15, 104);
            this.lbFechaMem.Name = "lbFechaMem";
            this.lbFechaMem.Size = new System.Drawing.Size(106, 13);
            this.lbFechaMem.TabIndex = 7;
            this.lbFechaMem.Text = "Fecha de nacimiento";
            this.lbFechaMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbApmMem
            // 
            this.lbApmMem.AutoSize = true;
            this.lbApmMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbApmMem.Location = new System.Drawing.Point(34, 78);
            this.lbApmMem.Name = "lbApmMem";
            this.lbApmMem.Size = new System.Drawing.Size(85, 13);
            this.lbApmMem.TabIndex = 5;
            this.lbApmMem.Text = "Apellido materno";
            this.lbApmMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbAppMem
            // 
            this.lbAppMem.AutoSize = true;
            this.lbAppMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbAppMem.Location = new System.Drawing.Point(36, 52);
            this.lbAppMem.Name = "lbAppMem";
            this.lbAppMem.Size = new System.Drawing.Size(83, 13);
            this.lbAppMem.TabIndex = 4;
            this.lbAppMem.Text = "Apellido paterno";
            this.lbAppMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbApmMem
            // 
            this.tbApmMem.Location = new System.Drawing.Point(127, 75);
            this.tbApmMem.MaxLength = 30;
            this.tbApmMem.Name = "tbApmMem";
            this.tbApmMem.Size = new System.Drawing.Size(274, 20);
            this.tbApmMem.TabIndex = 2;
            // 
            // tbAppMem
            // 
            this.tbAppMem.Location = new System.Drawing.Point(127, 49);
            this.tbAppMem.MaxLength = 30;
            this.tbAppMem.Name = "tbAppMem";
            this.tbAppMem.Size = new System.Drawing.Size(274, 20);
            this.tbAppMem.TabIndex = 1;
            // 
            // lbNombreMem
            // 
            this.lbNombreMem.AutoSize = true;
            this.lbNombreMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNombreMem.Location = new System.Drawing.Point(61, 26);
            this.lbNombreMem.Name = "lbNombreMem";
            this.lbNombreMem.Size = new System.Drawing.Size(58, 13);
            this.lbNombreMem.TabIndex = 1;
            this.lbNombreMem.Text = "Nombre (s)";
            this.lbNombreMem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNombreMem
            // 
            this.tbNombreMem.BackColor = System.Drawing.SystemColors.Window;
            this.tbNombreMem.Location = new System.Drawing.Point(127, 23);
            this.tbNombreMem.MaxLength = 30;
            this.tbNombreMem.Name = "tbNombreMem";
            this.tbNombreMem.Size = new System.Drawing.Size(274, 20);
            this.tbNombreMem.TabIndex = 0;
            // 
            // dgMembresias
            // 
            this.dgMembresias.AllowUserToAddRows = false;
            this.dgMembresias.AllowUserToDeleteRows = false;
            this.dgMembresias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMembresias.Location = new System.Drawing.Point(6, 198);
            this.dgMembresias.Name = "dgMembresias";
            this.dgMembresias.ReadOnly = true;
            this.dgMembresias.Size = new System.Drawing.Size(972, 337);
            this.dgMembresias.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nuPuntosMem);
            this.groupBox6.Controls.Add(this.cbTipoMem);
            this.groupBox6.Controls.Add(this.lbPuntosMem);
            this.groupBox6.Controls.Add(this.lbTipoMem);
            this.groupBox6.ForeColor = System.Drawing.Color.Silver;
            this.groupBox6.Location = new System.Drawing.Point(753, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(213, 138);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Datos de membresia";
            // 
            // lbPuntosMem
            // 
            this.lbPuntosMem.AutoSize = true;
            this.lbPuntosMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbPuntosMem.Location = new System.Drawing.Point(13, 52);
            this.lbPuntosMem.Name = "lbPuntosMem";
            this.lbPuntosMem.Size = new System.Drawing.Size(40, 13);
            this.lbPuntosMem.TabIndex = 9;
            this.lbPuntosMem.Text = "Puntos";
            this.lbPuntosMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTipoMem
            // 
            this.lbTipoMem.AutoSize = true;
            this.lbTipoMem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTipoMem.Location = new System.Drawing.Point(21, 26);
            this.lbTipoMem.Name = "lbTipoMem";
            this.lbTipoMem.Size = new System.Drawing.Size(28, 13);
            this.lbTipoMem.TabIndex = 8;
            this.lbTipoMem.Text = "Tipo";
            this.lbTipoMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTipoMem
            // 
            this.cbTipoMem.DisplayMember = "10";
            this.cbTipoMem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMem.FormattingEnabled = true;
            this.cbTipoMem.Items.AddRange(new object[] {
            "Standar",
            "Premium",
            "Vip"});
            this.cbTipoMem.Location = new System.Drawing.Point(59, 22);
            this.cbTipoMem.Name = "cbTipoMem";
            this.cbTipoMem.Size = new System.Drawing.Size(135, 21);
            this.cbTipoMem.TabIndex = 10;
            this.cbTipoMem.ValueMember = "10";
            // 
            // nuPuntosMem
            // 
            this.nuPuntosMem.Location = new System.Drawing.Point(59, 49);
            this.nuPuntosMem.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuPuntosMem.Name = "nuPuntosMem";
            this.nuPuntosMem.Size = new System.Drawing.Size(135, 20);
            this.nuPuntosMem.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.ControlBox = false;
            this.Controls.Add(this.lbCinemax);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpleados)).EndInit();
            this.gbEmpleado.ResumeLayout(false);
            this.gbEmpleado.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            this.tpMembresia.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMembresias)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPuntosMem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcPrincipal;
        private System.Windows.Forms.TabPage tpVenta;
        private System.Windows.Forms.TabPage tpEmpleado;
        private System.Windows.Forms.GroupBox gbEmpleado;
        private System.Windows.Forms.DataGridView dgEmpleados;
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
        private System.Windows.Forms.Button btActualizaEmpleado;
        private System.Windows.Forms.Button btEliminaEmpleado;
        private System.Windows.Forms.Button btInsertaEmpleado;
        private System.Windows.Forms.TextBox tbCelEmp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTelEmp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpFechaEmp;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.Label lbCinemax;
        private System.Windows.Forms.TabPage tpMembresia;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbMensajeMem;
        private System.Windows.Forms.Button btActualizaMem;
        private System.Windows.Forms.Button btEliminaMem;
        private System.Windows.Forms.Button btInsertaMem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbNumeroMem;
        private System.Windows.Forms.TextBox tbNumeroMem;
        private System.Windows.Forms.Label lbCalleMem;
        private System.Windows.Forms.TextBox tbCalleMem;
        private System.Windows.Forms.Label lbColoniaMem;
        private System.Windows.Forms.TextBox tbColoniaMem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dpFechaMem;
        private System.Windows.Forms.Label lbFechaMem;
        private System.Windows.Forms.Label lbApmMem;
        private System.Windows.Forms.Label lbAppMem;
        private System.Windows.Forms.TextBox tbApmMem;
        private System.Windows.Forms.TextBox tbAppMem;
        private System.Windows.Forms.Label lbNombreMem;
        private System.Windows.Forms.TextBox tbNombreMem;
        private System.Windows.Forms.DataGridView dgMembresias;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbPuntosMem;
        private System.Windows.Forms.Label lbTipoMem;
        private System.Windows.Forms.ComboBox cbTipoMem;
        private System.Windows.Forms.NumericUpDown nuPuntosMem;
    }
}

